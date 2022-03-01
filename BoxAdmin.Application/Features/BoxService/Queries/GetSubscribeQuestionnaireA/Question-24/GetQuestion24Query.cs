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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_24
{
    public class GetQuestion24Query : IRequest<GetQuestion24Response>
    {
    }

    public class GetQuestion24QueryHandler : IRequestHandler<GetQuestion24Query, GetQuestion24Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion24QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion24Response> Handle(GetQuestion24Query command, CancellationToken cancellationToken)
        {
            GetQuestion24Response response = new GetQuestion24Response();

            response.LevelType = "Personal"; //個人
            response.QuestionName = "你有小孩嗎?";

            response.Options.Add(new ChildOption { Value = "0", Name = "無" });
            response.Options.Add(new ChildOption { Value = "1", Name = "有" });

            return Task.FromResult(response);
        }
    }
}
