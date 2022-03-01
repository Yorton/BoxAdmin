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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_23
{
    public class GetQuestion23Query : IRequest<GetQuestion23Response>
    {
    }

    public class GetQuestion23QueryHandler : IRequestHandler<GetQuestion23Query, GetQuestion23Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion23QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion23Response> Handle(GetQuestion23Query command, CancellationToken cancellationToken)
        {
            GetQuestion23Response response = new GetQuestion23Response();

            response.LevelType = "Personal"; //個人
            response.QuestionName = "你的婚姻狀態";

            response.Options.Add(new MarriageOption { Value = "0", Name = "單身" });
            response.Options.Add(new MarriageOption { Value = "1", Name = "已婚" });
            
            return Task.FromResult(response);
        }
    }
}
