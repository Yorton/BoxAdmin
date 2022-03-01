using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_23
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer23Command : IRequest<GetAnswer23Response>
    {
        /// <summary>
        /// 婚姻狀態代號
        /// </summary>
        [SwaggerParameter(Description = "婚姻狀態代號")]
        public string MarriageSituationNo { get; set; }
    }

    public class GetAnswer23CommandHandler : IRequestHandler<GetAnswer23Command, GetAnswer23Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer23CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer23Response> Handle(GetAnswer23Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer23Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Personal-個人"                                       //隸屬階層名稱
            //"你的婚姻狀態"                                        //題目
            //command.MarriageSituationNo                           //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
