using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_6
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;


    public class GetAnswer6Command : IRequest<GetAnswer6Response>
    {
        /// <summary>
        /// 肩寬
        /// </summary>
        [SwaggerParameter(Description = "肩寬")]
        public int ShoulderWidth { get; set; }

        /// <summary>
        /// 胸圍
        /// </summary>
        [SwaggerParameter(Description = "胸圍")]
        public int Bust { get; set; }

        /// <summary>
        /// 腰圍
        /// </summary>
        [SwaggerParameter(Description = "腰圍")]
        public int WaistCircumference { get; set; }

        /// <summary>
        /// 臀圍
        /// </summary>
        [SwaggerParameter(Description = "臀圍")]
        public int HipCircumference { get; set; }

        /// <summary>
        /// 大腿圍
        /// </summary>
        [SwaggerParameter(Description = "大腿圍")]
        public int ThighCircumference { get; set; }
    }

    public class GetAnswer6CommandHandler : IRequestHandler<GetAnswer6Command, GetAnswer6Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer6CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer6Response> Handle(GetAnswer6Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer6Response();

            //資料的紀錄
            //_authenticatedUserService.UserId; //使用者
            //"Body Shape-身形"                 //隸屬階層名稱
            //"你的身形尺寸"                    //題目
            //command.ShoulderWidth             //答案
            //DateTime.Now                      //完成時間

            return response;
        }
    }
}
