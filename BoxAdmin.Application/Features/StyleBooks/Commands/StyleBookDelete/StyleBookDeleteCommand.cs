using AutoMapper;
using BoxAdmin.Application.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookDelete
{
    public class StyleBookDeleteCommand : IRequest<StyleBookDeleteResponse>
    {
        public Guid Id { get; set; }
    }

    public class StyleBookDeleteCommandHandler : IRequestHandler<StyleBookDeleteCommand, StyleBookDeleteResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public StyleBookDeleteCommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }

        public async Task<StyleBookDeleteResponse> Handle(StyleBookDeleteCommand command, CancellationToken cancellationToken)
        { 
            var response = new StyleBookDeleteResponse();

            var styleBook = await _context.StyleBooks
                    .Include(x => x.StyleBookDetails)
                    .SingleOrDefaultAsync(y => y.Id == command.Id, cancellationToken)
                    ?? throw new Exceptions.ApiException($"StyleBook '{command.Id}' is not found");

            _context.StyleBookDetails.RemoveRange(styleBook.StyleBookDetails);
            _context.StyleBooks.Remove(styleBook);
            _context.SaveChanges();

            return response;
        }
    }


    public class StyleBookDeleteResponse
    { 
    }
}
