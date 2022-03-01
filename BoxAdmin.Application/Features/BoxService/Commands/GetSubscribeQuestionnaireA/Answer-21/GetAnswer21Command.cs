using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_21
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer21Command : IRequest<GetAnswer21Response>
    {
        /// <summary>
        /// 生日
        /// </summary>
        [SwaggerParameter(Description = "生日")]
        public string Birthday { get; set; }
    }

    public class GetAnswer21CommandHandler : IRequestHandler<GetAnswer21Command, GetAnswer21Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer21CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer21Response> Handle(GetAnswer21Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer21Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Personal-個人"                                       //隸屬階層名稱
            //"你的生日"                                            //題目
            //command.Birthday                                      //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
