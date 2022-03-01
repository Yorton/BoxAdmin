using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_5
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer5Command : IRequest<GetAnswer5Response>
    {
        /// <summary>
        /// 身高
        /// </summary>
        [SwaggerParameter(Description = "身高")]
        public int Height { get; set; }

        /// <summary>
        /// 體重
        /// </summary>
        [SwaggerParameter(Description = "體重")]
        public int Weight { get; set; }
    }

    public class GetAnswer5CommandHandler : IRequestHandler<GetAnswer5Command, GetAnswer5Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer5CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer5Response> Handle(GetAnswer5Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer5Response();

            //資料的紀錄
            //_authenticatedUserService.UserId; //使用者
            //"Body Shape-身形"                 //隸屬階層名稱
            //"你的身高&體重"                   //題目
            //command.Height,command.Weight;    //答案
            //DateTime.Now                      //完成時間

            return response;
        }
    }
}
