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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_14
{
    public class GetQuestion14Query : IRequest<GetQuestion14Response>
    {
    }

    public class GetQuestion14QueryHandler : IRequestHandler<GetQuestion14Query, GetQuestion14Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion14QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<GetQuestion14Response> Handle(GetQuestion14Query command, CancellationToken cancellationToken)
        {
            GetQuestion14Response response = new GetQuestion14Response();

            response.LevelType = "Preference"; //偏好
            response.QuestionName = "以下褲腰高度你的穿著頻率是?";

            #region LowRise(低腰)
            response.LowRise = new LowRise
            {
                EnName = "LowRise",
                ChiName = "低腰",
                Options = new PantTopOption[]
                {
                    new PantTopOption { Name = "極少", Value = "1" },
                    new PantTopOption { Name = "很少", Value = "2" },
                    new PantTopOption { Name = "有時", Value = "3" },
                    new PantTopOption { Name = "經常", Value = "4" },
                    new PantTopOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            #region MidRise(中腰)
            response.MidRise = new MidRise
            {
                EnName = "MidRise",
                ChiName = "中腰",
                Options = new PantTopOption[]
                {
                    new PantTopOption { Name = "極少", Value = "1" },
                    new PantTopOption { Name = "很少", Value = "2" },
                    new PantTopOption { Name = "有時", Value = "3" },
                    new PantTopOption { Name = "經常", Value = "4" },
                    new PantTopOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            #region MidRise(高腰)
            response.HighRise = new HighRise
            {
                EnName = "HighRise",
                ChiName = "高腰",
                Options = new PantTopOption[]
                {
                    new PantTopOption { Name = "極少", Value = "1" },
                    new PantTopOption { Name = "很少", Value = "2" },
                    new PantTopOption { Name = "有時", Value = "3" },
                    new PantTopOption { Name = "經常", Value = "4" },
                    new PantTopOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            return Task.FromResult(response);
        }
    }
}
