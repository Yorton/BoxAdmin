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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_16
{
    public class GetQuestion16Query : IRequest<GetQuestion16Response>
    {
    }

    public class GetQuestion16QueryHandler : IRequestHandler<GetQuestion16Query, GetQuestion16Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion16QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<GetQuestion16Response> Handle(GetQuestion16Query command, CancellationToken cancellationToken)
        {
            GetQuestion16Response response = new GetQuestion16Response();

            response.LevelType = "Preference"; //偏好
            response.QuestionName = "哪些材質不會考慮穿上?";

            response.Options.Add(new TextureOption { Value = "A", Name = "人造皮革" });
            response.Options.Add(new TextureOption { Value = "B", Name = "真皮" });
            response.Options.Add(new TextureOption { Value = "C", Name = "動物毛" });
            response.Options.Add(new TextureOption { Value = "D", Name = "牛仔" });
            response.Options.Add(new TextureOption { Value = "Z", Name = "都可接受" });

            return Task.FromResult(response);
        }
    }
}
