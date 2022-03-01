using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;


namespace BoxAdmin.Application.Features.Reservations.Queries.GetCardMessageTemplate
{
    using BoxAdmin.Application.Interfaces.Contexts;

    public class GetCardMessageTemplateQuery : IRequest<GetCardMessageTemplateResponse>
    {
        public int Type { get; set; }
    }

    public class GetCardMessageTemplateHandler : IRequestHandler<GetCardMessageTemplateQuery, GetCardMessageTemplateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        public GetCardMessageTemplateHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetCardMessageTemplateResponse> Handle(GetCardMessageTemplateQuery command, CancellationToken cancellationToken)
        {
            var messageListQuery = new List<Domain.Entities.BoxContext.ReservationCardMessage>();
            if (command.Type == 1)
            {
                messageListQuery = await _context.ReservationCardMessages.Where(x => x.MessageType == "問候語").ToListAsync();
            }
            else if (command.Type == 2)
            {
                messageListQuery = await _context.ReservationCardMessages.Where(x => x.MessageType == "搭配文案").ToListAsync();
            }
            else
            {
                throw new ArgumentException("not found", $"{nameof(command.Type)}={command.Type}");
            }
            var response = new GetCardMessageTemplateResponse();
            foreach(var item in messageListQuery)
            {
                response.Items.Add(new CardMessageTemplateListItem()
                {
                    Title = item.Name,
                    MessageText = item.MessageText
                });
            }
            return response;
        }
    }
}
