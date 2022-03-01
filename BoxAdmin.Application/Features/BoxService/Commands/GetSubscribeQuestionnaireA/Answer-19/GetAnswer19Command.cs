using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_19
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer19Command : IRequest<GetAnswer19Response>
    {
        /// <summary>
        /// 嘗試服飾習慣代號
        /// </summary>
        [SwaggerParameter(Description = "嘗試服飾習慣代號")]
        public string TryNo { get; set; }
    }

    public class GetAnswer19CommandHandler : IRequestHandler<GetAnswer19Command, GetAnswer19Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer19CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer19Response> Handle(GetAnswer19Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer19Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Habit-習慣"                                          //隸屬階層名稱
            //"嘗試流行服飾的頻率?"                                 //題目
            //command.TryNo                                         //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
