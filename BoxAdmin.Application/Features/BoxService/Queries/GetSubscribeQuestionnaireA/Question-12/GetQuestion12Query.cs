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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_12
{
    public class GetQuestion12Query : IRequest<GetQuestion12Response>
    {
    }

    public class GetQuestion12QueryHandler : IRequestHandler<GetQuestion12Query, GetQuestion12Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion12QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion12Response> Handle(GetQuestion12Query command, CancellationToken cancellationToken)
        {
            GetQuestion12Response response = new GetQuestion12Response();

            response.LevelType = "Preference"; //偏好
            response.QuestionName = "以下褲子版型你的穿著頻率是?";

            #region SkinnyFit(緊身)
            response.SkinnyFit = new SkinnyFit
            {
                EnName = "SkinnyFit",
                ChiName = "緊身",
                Options = new PantStyleOption[] 
                { 
                    new PantStyleOption { Name = "極少", Value = "1" },
                    new PantStyleOption { Name = "很少", Value = "2" },
                    new PantStyleOption { Name = "有時", Value = "3" },
                    new PantStyleOption { Name = "經常", Value = "4" },
                    new PantStyleOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            #region Fit(合身)
            response.Fit = new Fit
            {
                EnName = "Fit",
                ChiName = "合身",
                Options = new PantStyleOption[]
                {
                    new PantStyleOption { Name = "極少", Value = "1" },
                    new PantStyleOption { Name = "很少", Value = "2" },
                    new PantStyleOption { Name = "有時", Value = "3" },
                    new PantStyleOption { Name = "經常", Value = "4" },
                    new PantStyleOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            #region Culottes(寬版)
            response.Culottes = new Culottes
            {
                EnName = "Culottes",
                ChiName = "寬版",
                Options = new PantStyleOption[]
                {
                    new PantStyleOption { Name = "極少", Value = "1" },
                    new PantStyleOption { Name = "很少", Value = "2" },
                    new PantStyleOption { Name = "有時", Value = "3" },
                    new PantStyleOption { Name = "經常", Value = "4" },
                    new PantStyleOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            return Task.FromResult(response);
        }
    }
}
