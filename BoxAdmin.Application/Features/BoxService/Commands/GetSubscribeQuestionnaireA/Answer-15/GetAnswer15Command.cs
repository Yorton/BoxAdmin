using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_15
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer15Command : IRequest<GetAnswer15Response>
    {
        /// <summary>
        /// 答案(複選)
        /// </summary>
        [SwaggerParameter(Description = "答案(複選)")]
        public List<string> Values { get; set; } = new List<string>();
    }

    public class GetAnswer15CommandHandler : IRequestHandler<GetAnswer15Command, GetAnswer15Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer15CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer15Response> Handle(GetAnswer15Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer15Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;   //使用者
            //"Preference-偏好"                   //隸屬階層名稱
            //"你不喜歡哪些花紋或元素?(複選)"     //題目
            //command.Values;                     //答案
            //DateTime.Now                        //完成時間

            return response;
        }
    }

}
