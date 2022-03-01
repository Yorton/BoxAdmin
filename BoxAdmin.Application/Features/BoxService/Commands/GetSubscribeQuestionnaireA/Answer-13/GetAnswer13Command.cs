using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_13
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer13Command : IRequest<GetAnswer13Response>
    {
        /// <summary>
        /// 短褲
        /// </summary>
        [SwaggerParameter(Description = "短褲")]
        public string ShortPants { get; set; }

        /// <summary>
        /// 五分褲
        /// </summary>
        [SwaggerParameter(Description = "五分褲")]
        public string Shorts { get; set; }

        /// <summary>
        /// 七分褲
        /// </summary>
        [SwaggerParameter(Description = "七分褲")]
        public string CalfLengthPants { get; set; }

        /// <summary>
        /// 九分褲
        /// </summary>
        [SwaggerParameter(Description = "九分褲")]
        public string AnkleLengthPants { get; set; }

        /// <summary>
        /// 落地褲
        /// </summary>
        [SwaggerParameter(Description = "落地褲")]
        public string FloorPants { get; set; }
    }

    public class GetAnswer13CommandHandler : IRequestHandler<GetAnswer13Command, GetAnswer13Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer13CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer13Response> Handle(GetAnswer13Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer13Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Preference-偏好"                                     //隸屬階層名稱
            //"以下褲子長度你的穿著頻率是?"                         //題目
            //command.ShortPants                                    //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
