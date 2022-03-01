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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_18
{
    public class GetQuestion18Query : IRequest<GetQuestion18Response>
    {
    }

    public class GetQuestion18QueryHandler : IRequestHandler<GetQuestion18Query, GetQuestion18Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion18QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion18Response> Handle(GetQuestion18Query command, CancellationToken cancellationToken)
        {
            GetQuestion18Response response = new GetQuestion18Response();

            response.LevelType = "Habit"; //習慣
            response.QuestionName = "通常在出門前，會花多少時間在穿搭打扮上呢?";

            response.Options.Add(new TimeOption { Value = "1", Name = "隨便穿不花時間" });
            response.Options.Add(new TimeOption { Value = "2", Name = "花費10分鐘左右" });
            response.Options.Add(new TimeOption { Value = "3", Name = "花費半小時以上" });
            
            return Task.FromResult(response);
        }
    }
}
