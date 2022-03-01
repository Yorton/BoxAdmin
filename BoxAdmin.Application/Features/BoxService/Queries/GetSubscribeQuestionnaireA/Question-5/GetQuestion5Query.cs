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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_5
{
    public class GetQuestion5Query : IRequest<GetQuestion5Response>
    {
    }

    public class GetQuestion5QueryHandler : IRequestHandler<GetQuestion5Query, GetQuestion5Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion5QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion5Response> Handle(GetQuestion5Query command, CancellationToken cancellationToken)
        {
            GetQuestion5Response response = new GetQuestion5Response();

            response.LevelType = "Body Shape"; //身形
            response.QuestionName = "你的身高&體重";

            return Task.FromResult(response);
        }
    }
}
