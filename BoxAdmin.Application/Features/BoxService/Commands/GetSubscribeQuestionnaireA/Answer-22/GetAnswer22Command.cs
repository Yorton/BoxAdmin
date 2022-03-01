using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_22
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer22Command : IRequest<GetAnswer22Response>
    {
        /// <summary>
        /// 產業
        /// </summary>
        [SwaggerParameter(Description = "產業")]
        public string Industry { get; set; }

        /// <summary>
        /// 其他產業說明
        /// </summary>
        [SwaggerParameter(Description = "其他產業說明")]
        public string IndustryOther { get; set; }

        /// <summary>
        /// 職能
        /// </summary>
        [SwaggerParameter(Description = "職能")]
        public string Competency { get; set; }

        /// <summary>
        /// 其他職能說明
        /// </summary>
        [SwaggerParameter(Description = "其他職能說明")]
        public string CompetencyOther { get; set; }

        /// <summary>
        /// 是否為管理職
        /// </summary>
        [SwaggerParameter(Description = "是否為管理職")]
        public bool Management { get; set; }
    }

    public class GetAnswer22CommandHandler : IRequestHandler<GetAnswer22Command, GetAnswer22Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer22CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer22Response> Handle(GetAnswer22Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer22Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Personal-個人"                                       //隸屬階層名稱
            //"你目前從事什麼類型的工作?"                           //題目
            //command.Industry                                      //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
