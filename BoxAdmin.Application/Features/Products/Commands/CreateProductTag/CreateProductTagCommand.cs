using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.Products.Commands.CreateProductTag
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;

    public class CreateProductTagCommand : IRequest<CreateProductTagResponse>
    {
        public string SeriesNo { get; set; }
        public List<CreateProductTagItem> Items { get; set; } = new List<CreateProductTagItem>();
    }

    public class CreateProductTagItem
    {
        public string SeriesNo { get; set; }
        public string Type { get; set; }
        public string GroupKey { get; set; }
        public string TagCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductTagCommand, CreateProductTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public CreateProductCommandHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CreateProductTagResponse> Handle(CreateProductTagCommand command, CancellationToken cancellationToken)
        {
            var response = new CreateProductTagResponse();

            // delete orginal items
            var tagToSeriesQuery = await _context.ProductTagToSeries.Where(x => x.SeriesNo == command.SeriesNo).ToListAsync(cancellationToken);

            _context.ProductTagToSeries.RemoveRange(tagToSeriesQuery);

            await _context.SaveChangesAsync(cancellationToken);

            // add new items

            command.Items.ForEach(x => 
            {
                _context.ProductTagToSeries.Add(new ProductTagToSeries()
                {
                    SeriesNo = x.SeriesNo,
                    Type = x.Type,
                    GroupKey = x.GroupKey,
                    TagCode = x.TagCode,
                    CreatedAt = x.CreatedAt
                });
            });

            await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }

    public class CreateProductTagResponse { }
}
