using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.Reservations.Commands.AddReservationLineItem
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using BoxAdmin.Framework.Results;

    /// <summary>
    /// 新增商品資料
    /// </summary>
    public class AddReservationLineItemCommand : IRequest<AddReservationLineItemResponse>
    {
        /// <summary>
        /// BOX預約單ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 搭配組資料
        /// </summary>
        public List<AddReservationLineGroup> Groups { get; set; }
    }

    /// <summary>
    /// 搭配組資料
    /// </summary>
    public class AddReservationLineGroup
    {
        /// <summary>
        /// GroupID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Group 排序
        /// </summary>
        public int SortNum { get; set; }

        /// <summary>
        /// 商品資料
        /// </summary>
        public List<AddReservationLineItem> Items { get; set; }

    }

    /// <summary>
    /// 商品資料
    /// </summary>
    public class AddReservationLineItem
    {
        /// <summary>
        /// 位置
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// 商品編號
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 建立來源(1:APP 2:收藏清單 3:猜你喜歡 4:客人不喜歡 5:搭配師自選)
        /// </summary>
        public int Source { get; set; }
    }


    public class AddReservationLineItemCommandHandler : IRequestHandler<AddReservationLineItemCommand, AddReservationLineItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public AddReservationLineItemCommandHandler(IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<AddReservationLineItemResponse> Handle(AddReservationLineItemCommand command, CancellationToken cancellationToken)
        {
            if (command == null || command.Id == new Guid())
            {
                throw new Exception("Id is null");
            }

            if (command.Groups == null && command.Groups.Count == 0)
            {
                throw new Exception("No Save Item Data");
            }

            var reservationQuery = await _context.Reservations
                 .Include(x => x.ReservationLineItemGroups)
                    .ThenInclude(it => it.ReservationLineItems)
                 .Include(x => x.ReservationLineItems)
                 .SingleOrDefaultAsync(x => x.Id == command.Id, cancellationToken) ??
                 throw new ArgumentException($"Reservations not found", $"{nameof(command.Id)}");
            
            using (var dbtc = _context.BeginTransaction)
            {
                try
                {
                    foreach (var groupRowData in command.Groups)
                    {
                        var group_id = string.IsNullOrEmpty(groupRowData.Id) ? Guid.NewGuid() : Guid.Parse(groupRowData.Id);
                        groupRowData.Id = group_id.ToString();

                        if (!reservationQuery.ReservationLineItemGroups.Any(w => w.Id == group_id))
                        {
                            _context.ReservationLineItemGroups.Add(new ReservationLineItemGroup
                            {
                                Id = group_id,
                                ReservationId = command.Id,
                                MatchingMessage = "",
                                SortNum = groupRowData.SortNum,
                                CreatedAt = DateTime.Now,
                                CreatedBy = _authenticatedUserService.UserId
                            });
                        }

                        var reservationGroupLineItems = reservationQuery.ReservationLineItems.Where(x => x.GroupId == group_id).ToList();

                        var resetItemsQuery =
                            from a in reservationGroupLineItems
                            join b in groupRowData.Items on a.Position equals b.Position into ab
                            from b in ab.DefaultIfEmpty()
                            select a;

                        foreach(var resetItem in resetItemsQuery)
                        {
                            resetItem.Sku = string.Empty;
                            resetItem.Status = 2;
                            resetItem.Source = 0;
                            resetItem.ModifiedAt = DateTime.Now;
                            resetItem.ModifiedBy = _authenticatedUserService.UserId;
                        }

                        foreach(var gpitem in groupRowData.Items)
                        {
                            var itemQuery = reservationQuery
                                .ReservationLineItems
                                .FirstOrDefault(x => x.GroupId == group_id && x.Position == gpitem.Position);

                            if (itemQuery == null)
                            {
                                _context.ReservationLineItems.Add(new ReservationLineItem
                                {
                                    Id = Guid.NewGuid(),
                                    ReservationId = command.Id,
                                    GroupId = group_id,
                                    Sku = gpitem.Sku,
                                    Position = gpitem.Position,
                                    DislikeReason = "-1",
                                    DislikeFeedback = false,
                                    CreatedAt = DateTime.Now,
                                    CreatedBy = _authenticatedUserService.UserId,
                                    Status = 1,
                                    Source = gpitem.Source
                                });
                            }
                            else
                            {
                                itemQuery.Sku = gpitem.Sku;
                                itemQuery.Status = 1;
                                itemQuery.ModifiedAt = DateTime.Now;
                                itemQuery.ModifiedBy = _authenticatedUserService.UserId;
                            }
                        }

                    }

                    var reservationLineItems = reservationQuery.ReservationLineItems.ToList();

                    //*1標記刪除*/
                    //if (reservationLineItems != null && reservationLineItems.Any(w => w.Status == 1))
                    //{
                    //    foreach (var item in reservationLineItems.Where(w => w.Status == 1).ToList())
                    //    {
                    //        item.Status = 2;
                    //        item.ModifiedAt = DateTime.Now;
                    //        item.ModifiedBy = _authenticatedUserService.UserId;
                    //    }
                    //    var c2 = await _context.SaveChangesAsync(cancellationToken);
                    //}

                    ///*新增資料與標記*/
                    //var allCount = 0;
                    //var groupIdx = 1;
                    //foreach (var group in command.Groups)
                    //{
                    //    group.SortNum = groupIdx++;



                    //    allCount += group.Items.Count;
                    //    if (group.Items.Any())
                    //    {
                    //        foreach (var item in group.Items)
                    //        {
                    //            var checkData1 = reservationLineItems.FirstOrDefault(w => w.GroupId == group.Id && w.Position == item.Position);
                    //            if (checkData1 == null || string.IsNullOrWhiteSpace(checkData1.Sku))
                    //            {
                    //                var checkData2 = reservationLineItems.FirstOrDefault(w => w.Sku == item.Sku && w.Status != 1);
                    //                if (checkData2 == null || string.IsNullOrWhiteSpace(checkData2.Sku))
                    //                {
                    //                    //新增資料
                    //                    _context.ReservationLineItems.Add(new ReservationLineItem
                    //                    {
                    //                        Id = Guid.NewGuid(),
                    //                        ReservationId = command.Id,
                    //                        GroupId = group.Id,
                    //                        Sku = item.Sku,
                    //                        Position = item.Position,
                    //                        DislikeReason = -1,
                    //                        DislikeFeedback = false,
                    //                        CreatedAt = DateTime.Now,
                    //                        CreatedBy = _authenticatedUserService.UserId,
                    //                        Status = 1,
                    //                        Source = item.Source
                    //                    });
                    //                }
                    //                else
                    //                {
                    //                    //更改商品所在位置
                    //                    checkData2.GroupId = group.Id;
                    //                    checkData2.Position = item.Position;
                    //                    checkData2.Source = item.Source;
                    //                    checkData2.Status = 1;
                    //                    checkData2.ModifiedAt = DateTime.Now;
                    //                    checkData2.ModifiedBy = _authenticatedUserService.UserId;
                    //                }
                    //            }
                    //            else
                    //            {
                    //                //更改位置上的資料
                    //                checkData1.Sku = item.Sku;
                    //                checkData1.Source = item.Source;
                    //                checkData1.Status = 1;
                    //                checkData1.ModifiedAt = DateTime.Now;
                    //                checkData1.ModifiedBy = _authenticatedUserService.UserId;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        var resetItems = reservationLineItems.Where(x => x.GroupId == group.Id).ToList();
                    //        foreach(var item in resetItems)
                    //        {
                    //            item.Sku = string.Empty;
                    //            item.ModifiedAt = DateTime.Now;
                    //            item.ModifiedBy = _authenticatedUserService.UserId;
                    //        }
                    //    }

                    //}

                    var count = await _context.SaveChangesAsync(cancellationToken);
                    dbtc.Commit();
                }
                catch (Exception e)
                {
                    dbtc.Rollback();
                    throw;
                }
            }
            return new AddReservationLineItemResponse();
        }
    }

}
