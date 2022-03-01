using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_9
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer9Command : IRequest<GetAnswer9Response>
    {
        /// <summary>
        /// 答案(複選)
        /// </summary>
        [SwaggerParameter(Description = "答案(複選)")]
        public List<string> Values { get; set; } = new List<string>();
    }

    public class GetAnswer9CommandHandler : IRequestHandler<GetAnswer9Command, GetAnswer9Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer9CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer9Response> Handle(GetAnswer9Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer9Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;           //使用者
            //"Body Shape-身形"                           //隸屬階層名稱
            //"你有自信的部位?(複選)"                     //題目
            //command.Values                              //答案
            //DateTime.Now                                //完成時間

            return response;
        }
    }
}
