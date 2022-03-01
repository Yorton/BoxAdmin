using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Application.DTOs.Settings;
using System.Threading;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_8
{
    public class GetQuestion8Query : IRequest<GetQuestion8Response>
    {
    }

    public class GetQuestion8QueryHandler : IRequestHandler<GetQuestion8Query, GetQuestion8Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion8QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion8Response> Handle(GetQuestion8Query command, CancellationToken cancellationToken)
        {
            GetQuestion8Response response = new GetQuestion8Response();

            response.LevelType = "Body Shape"; //身形
            response.QuestionName = "你的肩臀比例接近下面哪一種?";

            response.Options.Add(new ProportionOption { Value = "A", Name = "肩 > 臀" });
            response.Options.Add(new ProportionOption { Value = "B", Name = "肩 = 臀" });
            response.Options.Add(new ProportionOption { Value = "C", Name = "肩 < 臀" });

            return Task.FromResult(response);
        }
    }
}
