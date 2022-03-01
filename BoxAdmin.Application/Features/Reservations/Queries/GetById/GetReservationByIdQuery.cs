using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.Reservations.Queries.GetById
{
    using BoxAdmin.Application.DTOs.Settings;
    using BoxAdmin.Application.Interfaces.Contexts;

    public class GetReservationByIdQuery : IRequest<GetReservationByIdResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdResponse>
    {
        private readonly CommonSettings _commonSettings;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetReservationByIdQueryHandler(
            IOptions<CommonSettings> commonSettings,
            IMediator mediator, 
            IMapper mapper,
            IBoxDbContext context)
        {
            _commonSettings = commonSettings.Value;
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetReservationByIdResponse> Handle(GetReservationByIdQuery command, CancellationToken cancellationToken)
        {
            var responseObject = new GetReservationByIdResponse();

            // query data and validate
            var reservationQuery = await _context.Reservations
                .Include(a => a.ReservationRecipient)
                .Include(a => a.ReservationCustomer)
                .Include(a => a.ReservationCards)
                .SingleOrDefaultAsync(a => a.Id == command.Id, cancellationToken)
                ?? throw new ArgumentException("預約單資料不存在!");

            responseObject.Id = reservationQuery.Id;
            responseObject.BoxNo = reservationQuery.BoxNo;

            var subscribeQuery = await _mediator.Send(
                new Subscribes.Queries.GetSubscribeById.GetSubscribeByIdQuery() { Id = reservationQuery.SubscribeId }, cancellationToken);

            responseObject.SubscribeId = subscribeQuery.Id;
            responseObject.CustomerId = reservationQuery.CustomerId;

            #region 預約單類型
            responseObject.BoxType = reservationQuery.BoxType;
            if (reservationQuery.BoxType == 1)
                responseObject.BoxTypeName = "一般";
            else if (reservationQuery.BoxType == 2)
                responseObject.BoxTypeName = "加購";
            #endregion

            #region 預約單狀態
            var reservationStateQuery = await _context.ReservationStates.SingleAsync(a => a.Id == reservationQuery.State, cancellationToken: cancellationToken);
            responseObject.State = new ReservationState()
            {
                Id = reservationStateQuery.Id,
                Title = reservationStateQuery.Title
            };
            #endregion

            #region 編輯流程狀態 (0:待編輯 1:商品搭配 2:商品組合貼標 4:卡片製作)
            var flowStateMapping = new Dictionary<int, string>()
            {
                { 0, "待編輯" },
                { 1, "商品搭配" },
                { 2, "商品組合貼標" },
                { 4, "卡片製作" },
            };
            responseObject.FlowState = new ReservationFlowState()
            {
                Id = reservationQuery.FlowState,
                Title = flowStateMapping[reservationQuery.FlowState]
            };
            #endregion

            #region 搭配師資訊
            var matchmakerQuery = await _mediator.Send(
                new MatchingMakers.Queries.GetMatchingMakerById.GetMatchingMakerByIdQuery() { Id = reservationQuery.MatchmakerId }, cancellationToken);
            responseObject.MatchmakerId = matchmakerQuery.Id;
            responseObject.Matchmaker = new ReservationMatchmaker()
            {
                Id = matchmakerQuery.Id,
                Name = matchmakerQuery.Name
            };
            #endregion

            #region 預約單商品組合
            var reservationLineItemGroupQuery = await _context.ReservationLineItemGroups
                .Include(a => a.ReservationLineItems)
                .Where(a => a.ReservationId == reservationQuery.Id)
                .OrderBy(o => o.SortNum)
                .ToArrayAsync();

            foreach (var itemGroupQuery in reservationLineItemGroupQuery)
            {
                var itemGroup = new ReservationLineItemGroup();
                itemGroup.Id = itemGroupQuery.Id;
                itemGroup.MatchingMessage = itemGroupQuery.MatchingMessage;
                itemGroup.StyleId = itemGroupQuery.StyleId;
                itemGroup.OccasionId = itemGroupQuery.OccasionId;
                itemGroup.SortNum = itemGroupQuery.SortNum;
                itemGroup.HasStyleBook = false;

                foreach (var lineItemQuery in itemGroupQuery.ReservationLineItems)
                {
                    var lineItem = new ReservationLineItem();
                    lineItem.Id = lineItemQuery.Id;
                    lineItem.ReservationId = lineItemQuery.ReservationId;
                    lineItem.GroupId = itemGroupQuery.Id;
                    lineItem.Source = lineItemQuery.Source;
                    lineItem.Sku = lineItemQuery.Sku ?? string.Empty;
                    lineItem.DislikeFeedback = lineItemQuery.DislikeFeedback;
                    lineItem.DislikeReason = lineItemQuery.DislikeReason;
                    lineItem.CreatedAt = lineItemQuery.CreatedAt;

                    if (!string.IsNullOrEmpty(lineItem.Sku))
                    {
                        var skuInfo = await _mediator.Send(new Products.Queries.GetProductBySku.GetProductBySkuQuery() { Sku = lineItem.Sku });
                        lineItem.Series = skuInfo.Info.Series;
                        lineItem.ProductName = skuInfo.Info.Name;
                        lineItem.ImageUrl = skuInfo.Info.Image;
                        lineItem.Color = skuInfo.Info.Color;
                        lineItem.Size = skuInfo.Info.Size;
                        lineItem.Price = skuInfo.Info.Price;
                    }

                    itemGroup.Items.Add(lineItem);
                }

                // 判斷是否有在Stylebook
                if (itemGroupQuery.ReservationLineItems.Count == 2)
                {

                }

                responseObject.ItemGroups.Add(itemGroup);
            }
            #endregion

            #region 收件人資訊
            responseObject.Recipient = new ReservationRecipient
            {
                Name = reservationQuery.ReservationRecipient.Name,
                Mobile = reservationQuery.ReservationRecipient.Mobile,
                Zip = reservationQuery.ReservationRecipient.Zip,
                City = reservationQuery.ReservationRecipient.City,
                Region = reservationQuery.ReservationRecipient.Region,
                Address = reservationQuery.ReservationRecipient.Address
            };
            #endregion

            #region 會員資訊
            var customerInfoQuery = await _context.CustomerInfos.SingleOrDefaultAsync(c => c.CustomerId == reservationQuery.CustomerId);
            responseObject.Customer = new ReservationCustomer()
            {
                No = "",
                Mobile = reservationQuery.ReservationCustomer.Mobile,
                Name = reservationQuery.ReservationCustomer.Name
            };
            #endregion

            #region 卡片製作
            var cardQuery = reservationQuery.ReservationCards.FirstOrDefault();
            if (cardQuery != null)
            {
                responseObject.Card = new GetReservationById_ReservationCard()
                {
                    Id = cardQuery.Id,
                    Intro = cardQuery?.Intro,
                    Template = cardQuery?.Template ?? 0,
                    SignatureUrl = string.IsNullOrEmpty(cardQuery.SignatureUrl) ? string.Empty: $"{_commonSettings.BoxImageUrl}{cardQuery.SignatureUrl}"
                };
            }
            #endregion

            #region 問卷資料(假資料)
            responseObject.Surveys.Add(new ReservationSurvey() { Title = "場合", Answer = "聚會" });
            responseObject.Surveys.Add(new ReservationSurvey() { Title = "想收到", Answer = "洋裝" });
            #endregion

            return await Task.FromResult(responseObject);
        }
    }
}

