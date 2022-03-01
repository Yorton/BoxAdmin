using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_14
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer14Command : IRequest<GetAnswer14Response>
    {
        /// <summary>
        /// 低腰
        /// </summary>
        [SwaggerParameter(Description = "低腰")]
        public string LowRise { get; set; }

        /// <summary>
        /// 中腰
        /// </summary>
        [SwaggerParameter(Description = "中腰")]
        public string MidRise { get; set; }


        /// <summary>
        /// 高腰
        /// </summary>
        [SwaggerParameter(Description = "高腰")]
        public string HighRise { get; set; }
    }

    public class GetAnswer14CommandHandler : IRequestHandler<GetAnswer14Command, GetAnswer14Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer14CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer14Response> Handle(GetAnswer14Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer14Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Preference-偏好"                                     //隸屬階層名稱
            //"以下褲腰高度你的穿著頻率是?"                         //題目
            //command.LowRise                                       //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
