using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Coupons.Commands.MarketingActivitiesSendTargetListSubmit
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class MarketingActivitiesSendTargetListSubmitCommand : IRequest<MarketingActivitiesSendTargetListSubmitResponse>
    {
        /// <summary>
        /// 指定會員資料
        /// </summary>
        [SwaggerParameter(Description = "指定會員資料")]
        public List<SendTarget> SendTargetList { get; set; }
    }

    public class SendTarget
    {
        /// <summary>
        /// ID
        /// </summary>
        //[SwaggerParameter(Description = "ID")]
        //public Guid Id { get; set; }

        /// <summary>
        /// 活動ID
        /// </summary>
        [SwaggerParameter(Description = "活動ID")]
        public Guid MarketingActivitiesId { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        [SwaggerParameter(Description = "帳號")]
        public string Account { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        [SwaggerParameter(Description = "建立時間")]
        public string CreatedDate { get; set; }
    }


    public class MarketingActivitiesSendTargetListSubmitCommandHandler : IRequestHandler<MarketingActivitiesSendTargetListSubmitCommand, MarketingActivitiesSendTargetListSubmitResponse> 
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;


        public MarketingActivitiesSendTargetListSubmitCommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<MarketingActivitiesSendTargetListSubmitResponse> Handle(MarketingActivitiesSendTargetListSubmitCommand command, CancellationToken cancellationToken)
        {
            var response = new MarketingActivitiesSendTargetListSubmitResponse();

            if (command.SendTargetList != null && command.SendTargetList.Count > 0)
            {
                foreach (SendTarget sendTarget in command.SendTargetList)
                {
                    _context.MarketingActivitiesSendTargetLists.Add(new MarketingActivitiesSendTargetList
                    {
                        Id = Guid.NewGuid(),
                        MarketingActivitiesId = sendTarget.MarketingActivitiesId,
                        Account = sendTarget.Account,
                        CreatedDate = DateTime.Now
                    });
                }

                await _context.SaveChangesAsync(cancellationToken);

                response.UploadedCount = command.SendTargetList.Count;
                //return response;
                return await Task.FromResult(response);
            }
            else 
            {
                throw new Exceptions.ApiException("items empty");
            }

         
        }

    }
}
