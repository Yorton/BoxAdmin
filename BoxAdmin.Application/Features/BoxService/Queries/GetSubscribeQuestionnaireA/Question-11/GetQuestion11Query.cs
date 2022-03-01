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


namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_11
{
    public class GetQuestion11Query : IRequest<GetQuestion11Response>
    {
    }

    public class GetQuestion11QueryHandler : IRequestHandler<GetQuestion11Query, GetQuestion11Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion11QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion11Response> Handle(GetQuestion11Query command, CancellationToken cancellationToken)
        {
            GetQuestion11Response response = new GetQuestion11Response();

            response.LevelType = "Preference"; //偏好
            response.QuestionName = "平常的穿搭習慣-褲子多一些，還是裙子多一些呢?";

            response.Options.Add(new DressUpOption { Value = "A", Name = "褲子較多" });
            response.Options.Add(new DressUpOption { Value = "B", Name = "裙子較多" });
            response.Options.Add(new DressUpOption { Value = "C", Name = "兩者差不多" });

            return Task.FromResult(response);
        }
    }
}
