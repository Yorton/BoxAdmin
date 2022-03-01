using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Commands.GetSubscribeQuestionnaireA.Answer_18
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class GetAnswer18Command : IRequest<GetAnswer18Response>
    {
        /// <summary>
        /// 穿搭打扮習慣代號
        /// </summary>
        [SwaggerParameter(Description = "穿搭打扮習慣代號")]
        public string DressNo { get; set; }
    }

    public class GetAnswer18CommandHandler : IRequestHandler<GetAnswer18Command, GetAnswer18Response>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public GetAnswer18CommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<GetAnswer18Response> Handle(GetAnswer18Command command, CancellationToken cancellationToken)
        {
            var response = new GetAnswer18Response();

            //資料的紀錄
            //_authenticatedUserService.UserId;                     //使用者
            //"Habit-習慣"                                          //隸屬階層名稱
            //"通常在出門前，會花多少時間在穿搭打扮上呢?"           //題目
            //command.DressNo                                       //答案
            //DateTime.Now                                          //完成時間

            return response;
        }
    }
}
