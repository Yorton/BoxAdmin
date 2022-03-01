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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_4
{
    public class GetQuestion4Query : IRequest<GetQuestion4Response>
    {
    }

    public class GetQuestion4QueryHandler : IRequestHandler<GetQuestion4Query, GetQuestion4Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion4QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion4Response> Handle(GetQuestion4Query command, CancellationToken cancellationToken)
        {
            GetQuestion4Response response = new GetQuestion4Response();

            response.LevelType = "Style"; //風格
            response.QuestionName = "較少穿甚麼顏色的衣服?(複選)";

            response.Options.Add(new ColorOption { Name = "黑色", Value = "1-1" });
            response.Options.Add(new ColorOption { Name = "白色", Value = "1-2" });
            response.Options.Add(new ColorOption { Name = "紅色", Value = "1-3" });
            response.Options.Add(new ColorOption { Name = "酒紅色", Value = "1-4" });
            response.Options.Add(new ColorOption { Name = "橙色", Value = "2-1" });
            response.Options.Add(new ColorOption { Name = "深咖啡色", Value = "2-2" });
            response.Options.Add(new ColorOption { Name = "咖啡色", Value = "2-3" });
            response.Options.Add(new ColorOption { Name = "黃色", Value = "2-4" });

            //文件尚未定義其他顏色

            return Task.FromResult(response);
        }
    }
}
