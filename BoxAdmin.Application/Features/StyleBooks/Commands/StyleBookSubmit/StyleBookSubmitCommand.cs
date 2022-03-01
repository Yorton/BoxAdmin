using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookSubmit
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;

    public class StyleBookSubmitCommand : IRequest<StyleBookSubmitResponse>
    {
        public string Id { get; set; }
        public Guid MatchmakerInfoId { get; set; }
        public Guid StyleId { get; set; }
        public Guid OccasionId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public List<StyleBookItem> Items { get; set; } = new List<StyleBookItem>();

        public class StyleBookItem
        {
            public string Series { get; set; }
            public string Color { get; set; }
            public string CatelogName { get; set; }
        }
    }

    public class StyleBookSubmitCommandHandler : IRequestHandler<StyleBookSubmitCommand, StyleBookSubmitResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public StyleBookSubmitCommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<StyleBookSubmitResponse> Handle(StyleBookSubmitCommand command, CancellationToken cancellationToken)
        {
            var response = new StyleBookSubmitResponse();
            StyleBook styleBook = null;
            var isNewStyleBook = false;

            if ((command.Id ?? "") == string.Empty)
            {
                isNewStyleBook = true;
            }
            else
            {
                var styleBookId = Guid.Parse(command.Id ?? "");
                styleBook = _context.StyleBooks
                    .Include(x => x.StyleBookDetails)
                    .SingleOrDefault(a => a.Id == styleBookId)
                    ?? throw new Exceptions.ApiException($"StyleBook '{command.Id}' is not found");
            }

            if (isNewStyleBook)
            {
                #region Add

                // 圖片上傳

                styleBook = new StyleBook()
                {
                    Id = Guid.NewGuid(),
                    StyleId = command.StyleId,
                    OccasionId = command.OccasionId,
                    MatchmakerInfoId = command.MatchmakerInfoId,
                    Name = command?.Name ?? string.Empty,
                    ImageUrl = string.Empty,
                    Sort = 1,
                    State = 0,
                    CreatedDate = DateTime.Now,
                    Creator = _authenticatedUserService.UserId,
                    ModifyDate = DateTime.Now,
                    Modifier = _authenticatedUserService.UserId,
                };

                foreach (var item in command.Items)
                {
                    var image = await _context.ProductImages.FirstOrDefaultAsync(
                        x => x.Type == 2 && x.Series == item.Series && x.Color == item.Color, cancellationToken: cancellationToken);

                    styleBook.StyleBookDetails.Add(new StyleBookDetail()
                    {
                        Id = Guid.NewGuid(),
                        Series = item.Series,
                        StyleBookId = styleBook.Id,
                        ImageUrl = $"{image.ImagePath}{image.Filename}",
                        CatelogName = item.CatelogName,
                        Color = item.Color,
                        CreatedDate = DateTime.Now,
                        Creator = _authenticatedUserService.UserId,
                        ModifyDate = DateTime.Now,
                        Modifier = _authenticatedUserService.UserId,
                    });
                };

                _context.StyleBooks.Add(styleBook);

                #endregion
            }
            else
            {
                #region Update

                // 主檔
                styleBook.StyleId = command.StyleId;
                styleBook.OccasionId = command.OccasionId;
                styleBook.MatchmakerInfoId = command.MatchmakerInfoId;
                styleBook.ModifyDate = DateTime.Now;
                styleBook.Modifier = _authenticatedUserService.UserId;
                
                // 特殊處理
                styleBook.ImageUrl = command.ImageUrl == string.Empty ? string.Empty : styleBook.ImageUrl;

                // 明細
                _context.StyleBookDetails.RemoveRange(styleBook.StyleBookDetails.ToArray());
                foreach (var item in command.Items)
                {
                    var image = await _context.ProductImages.FirstOrDefaultAsync(
                        x => x.Type == 2 && x.Series == item.Series && x.Color == item.Color, cancellationToken: cancellationToken);

                    _context.StyleBookDetails.Add(new StyleBookDetail()
                    {
                        Id = Guid.NewGuid(),
                        Series = item.Series,
                        StyleBookId = styleBook.Id,
                        ImageUrl = $"{image.ImagePath}{image.Filename}",
                        CatelogName = item.CatelogName,
                        Color = item.Color,
                        CreatedDate = DateTime.Now,
                        Creator = _authenticatedUserService.UserId,
                        ModifyDate = DateTime.Now,
                        Modifier = _authenticatedUserService.UserId,
                    });
                }
                #endregion
            }

            await _context.SaveChangesAsync(cancellationToken);

            var sb = await _mediator.Send(
                new Queries.GetStyleBookById.GetStyleBookByIdQuery() { Id = styleBook.Id }, cancellationToken);

            response.Id = sb.Id;
            response.State = sb.State;
            response.ImageUrl = sb.ImageUrl;
            response.StyleId = sb.StyleId;
            response.OccasionId = sb.OccasionId;
            response.CreatedAt = sb.CreatedAt;
            response.CreatedBy = sb.CreatedBy;
            response.ModifyDate = sb.ModifyDate;
            response.Modifier = sb.Modifier;
            foreach (var item in sb.Items)
            {
                response.Items.Add(new Queries.GetStyleBookById.StyleBookProduct()
                {
                    StyleBookId = item.StyleBookId,
                    Series = item.Series,
                    Color = item.Color,
                    ImageUrl = item.ImageUrl,
                    CatelogName = item.CatelogName
                });
            }

            if (sb.Matchmaker != null)
            {
                response.Matchmaker = new Queries.GetStyleBookById.Matchmaker()
                {
                    Id = sb.Matchmaker.Id,
                    Name = sb.Matchmaker.Name
                };
            }

            return response;
        }
    }
}
