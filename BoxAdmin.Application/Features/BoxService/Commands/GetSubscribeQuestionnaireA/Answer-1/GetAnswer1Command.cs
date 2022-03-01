using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_1
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class Answer 
    {
        /// <summary>
        /// 選項編號
        /// </summary>
        [SwaggerParameter(Description = "選項編號")]
        public string No { get; set; }

        /// <summary>
        /// 選項值(1 = (Dislike) 不喜歡, 3 = (Normal) 普通, 5= (Like) 喜歡)
        /// </summary>
        [SwaggerParameter(Description = "選項值")]
        public string Value { get; set; }
    }

    public class GetAnswer1Command : IRequest<GetAnswer1Response>
    {
        /// <summary>
        /// 答案
        /// </summary>
        [SwaggerParameter(Description = "答案")]
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }

    public class GetAnswer1CommandHandler : IRequestHandler<GetAnswer1Command, GetAnswer1Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer1CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer1Response> Handle(GetAnswer1Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer1Response();

            //資料的紀錄
            //_authenticatedUserService.UserId; //使用者
            //"Style-風格"                      //隸屬階層名稱
            //"這是你喜歡的風格?"               //題目
            //command.Answers;                  //答案
            //DateTime.Now                      //完成時間

            return response;
        }
    }

}
