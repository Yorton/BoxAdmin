using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_11
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer11Command : IRequest<GetAnswer11Response>
    {
        /// <summary>
        /// 穿搭偏好代號
        /// </summary>
        [SwaggerParameter(Description = "穿搭偏好代號")]
        public string PreferenceNo { get; set; }
    }

    public class GetAnswer11CommandHandler : IRequestHandler<GetAnswer11Command, GetAnswer11Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer11CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer11Response> Handle(GetAnswer11Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer11Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Preference-偏好"                                     //隸屬階層名稱
            //"平常的穿搭習慣-褲子多一些，還是裙子多一些呢?"        //題目
            //command.Shoulder                                      //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
