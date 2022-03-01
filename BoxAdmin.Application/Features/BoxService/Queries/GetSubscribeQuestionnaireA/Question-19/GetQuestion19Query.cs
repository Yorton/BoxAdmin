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


namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_19
{
    public class GetQuestion19Query : IRequest<GetQuestion19Response>
    {
    }

    public class GetQuestion19QueryHandler : IRequestHandler<GetQuestion19Query, GetQuestion19Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion19QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion19Response> Handle(GetQuestion19Query command, CancellationToken cancellationToken)
        {
            GetQuestion19Response response = new GetQuestion19Response();

            response.LevelType = "Habit"; //習慣
            response.QuestionName = "嘗試流行服飾的頻率?";

            response.Options.Add(new FrequencyOption { Value = "1", Name = "很少" });
            response.Options.Add(new FrequencyOption { Value = "2", Name = "偶爾" });
            response.Options.Add(new FrequencyOption { Value = "3", Name = "總是" });

            return Task.FromResult(response);
        }
    }
}
