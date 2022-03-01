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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_3
{
    public class GetQuestion3Query : IRequest<GetQuestion3Response>
    {
    }

    public class GetQuestion3QueryHandler : IRequestHandler<GetQuestion3Query, GetQuestion3Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion3QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion3Response> Handle(GetQuestion3Query command, CancellationToken cancellationToken)
        {
            GetQuestion3Response response = new GetQuestion3Response();

            response.LevelType = "Style"; //風格
            response.QuestionName = "喜歡穿甚麼色系的衣服?(複選)";

            response.Options.Add(new ColorToneOption { Value = "1", Name = "冷色系"});
            response.Options.Add(new ColorToneOption { Value = "2", Name = "暖色系" });
            response.Options.Add(new ColorToneOption { Value = "3", Name = "溫柔色系" });
            response.Options.Add(new ColorToneOption { Value = "4", Name = "銳利色系" });
            response.Options.Add(new ColorToneOption { Value = "5", Name = "大地色系" });
            response.Options.Add(new ColorToneOption { Value = "6", Name = "無彩色系" });

            return Task.FromResult(response);
        }
    }
}
