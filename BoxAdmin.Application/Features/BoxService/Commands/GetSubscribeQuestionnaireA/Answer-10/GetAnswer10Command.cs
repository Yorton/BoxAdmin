using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_10
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer10Command : IRequest<GetAnswer10Response>
    {
        /// <summary>
        /// 肩膀
        /// </summary>
        [SwaggerParameter(Description = "肩膀")]
        public string Shoulder { get; set; }

        /// <summary>
        /// 臉部
        /// </summary>
        [SwaggerParameter(Description = "臉部")]
        public string Face { get; set; }

        /// <summary>
        /// 手臂
        /// </summary>
        [SwaggerParameter(Description = "手臂")]
        public string Arm { get; set; }

        /// <summary>
        /// 脖子
        /// </summary>
        [SwaggerParameter(Description = "脖子")]
        public string Neck { get; set; }

        /// <summary>
        /// 背部
        /// </summary>
        [SwaggerParameter(Description = "背部")]
        public string Back { get; set; }

        /// <summary>
        /// 胸部
        /// </summary>
        [SwaggerParameter(Description = "胸部")]
        public string Chest { get; set; }

        /// <summary>
        /// 腰部
        /// </summary>
        [SwaggerParameter(Description = "腰部")]
        public string Loins { get; set; }

        /// <summary>
        /// 腹部
        /// </summary>
        [SwaggerParameter(Description = "腹部")]
        public string Belly { get; set; }

        /// <summary>
        /// 臀部
        /// </summary>
        [SwaggerParameter(Description = "臀部")]
        public string Hip { get; set; }

        /// <summary>
        /// 髖部
        /// </summary>
        [SwaggerParameter(Description = "髖部")]
        public string HipBone { get; set; }

        /// <summary>
        /// 腿
        /// </summary>
        [SwaggerParameter(Description = "腿")]
        public string Leg { get; set; }

        /// <summary>
        /// 大腿
        /// </summary>
        [SwaggerParameter(Description = "大腿")]
        public string Thigh { get; set; }

        /// <summary>
        /// 小腿
        /// </summary>
        [SwaggerParameter(Description = "小腿")]
        public string Shank { get; set; }
    }

    public class GetAnswer10CommandHandler : IRequestHandler<GetAnswer10Command, GetAnswer10Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer10CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer10Response> Handle(GetAnswer10Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer10Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;           //使用者
            //"Body Shape-身形"                           //隸屬階層名稱
            //"想要修飾的部位?(複選)"                     //題目
            //command.Shoulder                            //答案
            //DateTime.Now                                //完成時間

            return response;
        }
    }

}
