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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_9
{
    public class GetQuestion9Query : IRequest<GetQuestion9Response>
    {
    }

    public class GetQuestion9QueryHandler : IRequestHandler<GetQuestion9Query, GetQuestion9Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion9QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion9Response> Handle(GetQuestion9Query command, CancellationToken cancellationToken)
        {
            GetQuestion9Response response = new GetQuestion9Response();

            response.LevelType = "Body Shape"; //身形
            response.QuestionName = "你有自信的部位?(複選)";

            response.Options.Add(new ConfidentPartOption { Value = "1", Name = "手臂" });
            response.Options.Add(new ConfidentPartOption { Value = "2", Name = "脖子" });
            response.Options.Add(new ConfidentPartOption { Value = "3", Name = "背部" });
            response.Options.Add(new ConfidentPartOption { Value = "4", Name = "鎖骨" });
            response.Options.Add(new ConfidentPartOption { Value = "5", Name = "腰部" });
            response.Options.Add(new ConfidentPartOption { Value = "6", Name = "胸部" });
            response.Options.Add(new ConfidentPartOption { Value = "7", Name = "臀部" });
            response.Options.Add(new ConfidentPartOption { Value = "8", Name = "腹部" });
            response.Options.Add(new ConfidentPartOption { Value = "9", Name = "大腿" });
            response.Options.Add(new ConfidentPartOption { Value = "10", Name = "小腿" });
            response.Options.Add(new ConfidentPartOption { Value = "99", Name = "無" });
          
            return Task.FromResult(response);
        }
    }
}
