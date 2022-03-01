using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_20
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer20Command : IRequest<GetAnswer20Response>
    {
        /// <summary>
        /// 體驗代號
        /// </summary>
        [SwaggerParameter(Description = "體驗代號")]
        public string Experience { get; set; }

        /// <summary>
        /// 體驗說明
        /// </summary>
        [SwaggerParameter(Description = "體驗說明")]
        public string Other { get; set; }
    }

    public class GetAnswer20CommandHandler : IRequestHandler<GetAnswer20Command, GetAnswer20Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer20CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer20Response> Handle(GetAnswer20Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer20Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Habit-習慣"                                          //隸屬階層名稱
            //"想從iShebox獲得什麼樣的體驗?"                        //題目
            //command.Experience                                    //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
