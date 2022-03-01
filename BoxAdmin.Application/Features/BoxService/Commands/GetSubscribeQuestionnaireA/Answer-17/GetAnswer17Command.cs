using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_17
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer17Command : IRequest<GetAnswer17Response>
    {
        /// <summary>
        /// 上衣
        /// </summary>
        [SwaggerParameter(Description = "上衣")]
        public string TopClothes { get; set; }

        /// <summary>
        /// 下身
        /// </summary>
        [SwaggerParameter(Description = "下身")]
        public string Bottoms { get; set; }

        /// <summary>
        /// 洋裝
        /// </summary>
        [SwaggerParameter(Description = "洋裝")]
        public string Dress { get; set; }

        /// <summary>
        /// 外套
        /// </summary>
        [SwaggerParameter(Description = "外套")]
        public string Outerwear { get; set; }

        /// <summary>
        /// 飾品
        /// </summary>
        [SwaggerParameter(Description = "飾品")]
        public string Accessory { get; set; }
    }

    public class GetAnswer17CommandHandler : IRequestHandler<GetAnswer17Command, GetAnswer17Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer17CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer17Response> Handle(GetAnswer17Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer17Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Habit-習慣"                                          //隸屬階層名稱
            //"各項單品可接受的價位大概落在多少(NTD)?"              //題目
            //command.TopClothes                                    //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
