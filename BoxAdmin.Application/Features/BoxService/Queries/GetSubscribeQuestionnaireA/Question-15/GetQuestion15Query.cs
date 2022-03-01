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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_15
{
    public class GetQuestion15Query : IRequest<GetQuestion15Response>
    {
    }

    public class GetQuestion15QueryHandler : IRequestHandler<GetQuestion15Query, GetQuestion15Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion15QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<GetQuestion15Response> Handle(GetQuestion15Query command, CancellationToken cancellationToken)
        {
            GetQuestion15Response response = new GetQuestion15Response();

            response.LevelType = "Preference"; //偏好
            response.QuestionName = "你不喜歡哪些花紋或元素?(複選)";

            response.Options.Add(new PatternOption { Name = "條紋", Value = "1-1" });
            response.Options.Add(new PatternOption { Name = "格紋", Value = "1-2" });
            response.Options.Add(new PatternOption { Name = "動物紋", Value = "1-3" });
            response.Options.Add(new PatternOption { Name = "卡通圖案", Value = "1-4" });
            response.Options.Add(new PatternOption { Name = "小碎花", Value = "2-1" });
            response.Options.Add(new PatternOption { Name = "大印花", Value = "2-2" });
            response.Options.Add(new PatternOption { Name = "點點", Value = "2-3" });
            response.Options.Add(new PatternOption { Name = "民族圖案", Value = "2-4" });

            //文件尚未定義其他花紋或元素

            return Task.FromResult(response);
        }
    }
}
