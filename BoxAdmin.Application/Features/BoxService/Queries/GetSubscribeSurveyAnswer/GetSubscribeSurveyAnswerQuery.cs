using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Application.DTOs.Settings;
using System.Threading;
using BoxAdmin.Domain.Entities.BoxContext;
using Newtonsoft.Json;
using System.Reflection;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeSurveyAnswer
{
    public class GetSubscribeSurveyAnswerQuery : IRequest<List<GetSubscribeSurveyAnswerResponse>>
    {
        /// <summary>
        /// 會員ID
        /// </summary>
        [SwaggerParameter(Description = "會員ID")]
        public string CustomerId { get; set; }

        /// <summary>
        /// BoxID
        /// </summary>
        [SwaggerParameter(Description = "BoxID")]
        public string ReservationId { get; set; }

        /// <summary>
        /// 問卷類型
        /// </summary>
        [SwaggerParameter(Description = "問卷類型")]
        public string SurveyAnswerType { get; set; }
    }

    public class GetSubscribeSurveyAnswerQueryHandler : IRequestHandler<GetSubscribeSurveyAnswerQuery, List<GetSubscribeSurveyAnswerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IMediator _mediator;

        public GetSubscribeSurveyAnswerQueryHandler(IMapper mapper, IBoxDbContext context, IMediator mediator)
        {
            _mapper = mapper;
            _context = context;
            _mediator = mediator;
        }

        public async Task<List<GetSubscribeSurveyAnswerResponse>> Handle(GetSubscribeSurveyAnswerQuery command, CancellationToken cancellationToken)
        {
            var boxSurveyAnswerQuery = await _mediator.Send(new BoxOrders.Queries.GetBoxSurveyAnswer.GetBoxSurveyAnswerQuery() { 
                                                                                    CustomerId = command.CustomerId, 
                                                                                    SurveyAnswerType = command.SurveyAnswerType 
                                                                                 }, 
                                                                                 cancellationToken);

            List<GetSubscribeSurveyAnswerResponse> list = null;

            if (boxSurveyAnswerQuery != null) 
            {
                list = new List<GetSubscribeSurveyAnswerResponse>();
                foreach (BoxOrders.Queries.GetBoxSurveyAnswer.GetBoxSurveyAnswerResponse item in boxSurveyAnswerQuery) 
                {
                    list.Add(new GetSubscribeSurveyAnswerResponse
                    {
                        No = item.No,
                        NoName = item.NoName,
                        SubNoName = item.SubNoName,
                        Answer = item.Answer
                    });
                }
            }

            return await Task.FromResult(list);
        }
    }
}
