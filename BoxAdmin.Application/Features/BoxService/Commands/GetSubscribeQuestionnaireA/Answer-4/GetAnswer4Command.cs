using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_4
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer4Command : IRequest<GetAnswer4Response>
    {
        /// <summary>
        /// 答案(複選)
        /// </summary>
        [SwaggerParameter(Description = "答案(複選)")]
        public List<string> Values { get; set; } = new List<string>();
    }

    public class GetAnswer4CommandHandler : IRequestHandler<GetAnswer4Command, GetAnswer4Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer4CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer4Response> Handle(GetAnswer4Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer4Response();

            //資料的紀錄
            //_authenticatedUserService.UserId; //使用者
            //"Style-風格"                      //隸屬階層名稱
            //"較少穿甚麼顏色的衣服?(複選)"     //題目
            //command.Values;                   //答案
            //DateTime.Now                      //完成時間

            return response;
        }
    }
}
