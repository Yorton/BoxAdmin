using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_12
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer12Command : IRequest<GetAnswer12Response>
    {
        /// <summary>
        /// 緊身
        /// </summary>
        [SwaggerParameter(Description = "緊身")]
        public string SkinnyFit { get; set; }

        /// <summary>
        /// 合身
        /// </summary>
        [SwaggerParameter(Description = "合身")]
        public string Fit { get; set; }

        /// <summary>
        /// 寬版
        /// </summary>
        [SwaggerParameter(Description = "寬版")]
        public string Culottes { get; set; }
    }

    public class GetAnswer12CommandHandler : IRequestHandler<GetAnswer12Command, GetAnswer12Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer12CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer12Response> Handle(GetAnswer12Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer12Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Preference-偏好"                                     //隸屬階層名稱
            //"以下褲子版型你的穿著頻率是?"                         //題目
            //command.SkinnyFit                                     //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
