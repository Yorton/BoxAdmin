using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_7
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class Brassier
    {
        /// <summary>
        /// 罩杯尺碼
        /// </summary>
        [SwaggerParameter(Description = "罩杯尺碼")]
        public string Bra { get; set; }

        /// <summary>
        /// 內衣尺碼
        /// </summary>
        [SwaggerParameter(Description = "內衣尺碼")]
        public List<string> Size { get; set; } = new List<string>();
    }

    public class GetAnswer7Command : IRequest<GetAnswer7Response>
    {
        /// <summary>
        /// 上衣尺碼
        /// </summary>
        [SwaggerParameter(Description = "上衣尺碼")]
        public List<string> TopClothes { get; set; } = new List<string>();

        /// <summary>
        /// 下著尺碼
        /// </summary>
        [SwaggerParameter(Description = "下著尺碼")]
        public List<string> Bottoms { get; set; } = new List<string>();

        /// <summary>
        /// 牛仔褲尺碼
        /// </summary>
        [SwaggerParameter(Description = "牛仔褲尺碼")]
        public List<string> Jeans { get; set; } = new List<string>();

        /// <summary>
        /// 洋裝尺碼
        /// </summary>
        [SwaggerParameter(Description = "洋裝尺碼")]
        public List<string> Dress { get; set; } = new List<string>();

        /// <summary>
        /// 內衣尺碼
        /// </summary>
        [SwaggerParameter(Description = "內衣尺碼")]
        public Brassier Brassier { get; set; }
    }

    public class GetAnswer7CommandHandler : IRequestHandler<GetAnswer7Command, GetAnswer7Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer7CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer7Response> Handle(GetAnswer7Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer7Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;           //使用者
            //"Body Shape-身形"                           //隸屬階層名稱
            //"請填入平常的購衣尺碼(複選，最多兩項)"      //題目
            //command.TopClothes                          //答案
            //DateTime.Now                                //完成時間

            return response;
        }
    }

}
