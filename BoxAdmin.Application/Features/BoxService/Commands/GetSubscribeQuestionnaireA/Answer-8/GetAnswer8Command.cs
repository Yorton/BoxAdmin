using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_8
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer8Command : IRequest<GetAnswer8Response>
    {
        /// <summary>
        /// 比例代號
        /// </summary>
        [SwaggerParameter(Description = "比例代號")]
        public string ProportionNo { get; set; } 
    }

    public class GetAnswer8CommandHandler : IRequestHandler<GetAnswer8Command, GetAnswer8Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer8CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer8Response> Handle(GetAnswer8Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer8Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;           //使用者
            //"Body Shape-身形"                           //隸屬階層名稱
            //"你的肩臀比例接近下面哪一種?"               //題目
            //command.ProportionNo                        //答案
            //DateTime.Now                                //完成時間

            return response;
        }
    }
}
