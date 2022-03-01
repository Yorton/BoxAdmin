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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_20
{
    public class GetQuestion20Query : IRequest<GetQuestion20Response>
    {
    }

    public class GetQuestion20QueryHandler : IRequestHandler<GetQuestion20Query, GetQuestion20Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion20QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion20Response> Handle(GetQuestion20Query command, CancellationToken cancellationToken)
        {
            GetQuestion20Response response = new GetQuestion20Response();

            response.LevelType = "Habit"; //習慣
            response.QuestionName = "想從iShebox獲得什麼樣的體驗?";

            response.Options.Add(new ExperienceOption { Value = "1", Name = "買份禮物給自己" });
            response.Options.Add(new ExperienceOption { Value = "2", Name = "嘗試新的穿搭風格" });
            response.Options.Add(new ExperienceOption { Value = "3", Name = "獲得時下流行資訊" });
            response.Options.Add(new ExperienceOption { Value = "4", Name = "節省購衣穿搭的時間" });
            response.Options.Add(new ExperienceOption { Value = "5", Name = "獲得專屬搭配師的穿搭建議" });
            response.Options.Add(new ExperienceOption { Value = "9", Name = "其他" });

            return Task.FromResult(response);
        }
    }
}
