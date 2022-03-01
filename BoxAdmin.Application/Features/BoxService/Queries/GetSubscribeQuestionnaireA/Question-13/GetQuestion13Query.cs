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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_13
{
    public class GetQuestion13Query : IRequest<GetQuestion13Response>
    {
    }

    public class GetQuestion13QueryHandler : IRequestHandler<GetQuestion13Query, GetQuestion13Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion13QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion13Response> Handle(GetQuestion13Query command, CancellationToken cancellationToken)
        {
            GetQuestion13Response response = new GetQuestion13Response();

            response.LevelType = "Preference"; //偏好
            response.QuestionName = "以下褲子長度你的穿著頻率是?";

            #region ShortPants(短褲)
            response.ShortPants = new ShortPants
            {
                EnName = "ShortPants",
                ChiName = "短褲",
                Options = new PantLengthOption[]
                {
                    new PantLengthOption { Name = "極少", Value = "1" },
                    new PantLengthOption { Name = "很少", Value = "2" },
                    new PantLengthOption { Name = "有時", Value = "3" },
                    new PantLengthOption { Name = "經常", Value = "4" },
                    new PantLengthOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            #region Shorts(五分褲)
            response.Shorts = new Shorts
            {
                EnName = "Shorts",
                ChiName = "五分褲",
                Options = new PantLengthOption[]
                {
                    new PantLengthOption { Name = "極少", Value = "1" },
                    new PantLengthOption { Name = "很少", Value = "2" },
                    new PantLengthOption { Name = "有時", Value = "3" },
                    new PantLengthOption { Name = "經常", Value = "4" },
                    new PantLengthOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            #region CalfLengthPants(七分褲)
            response.CalfLengthPants = new CalfLengthPants
            {
                EnName = "CalfLengthPants",
                ChiName = "七分褲",
                Options = new PantLengthOption[]
                {
                    new PantLengthOption { Name = "極少", Value = "1" },
                    new PantLengthOption { Name = "很少", Value = "2" },
                    new PantLengthOption { Name = "有時", Value = "3" },
                    new PantLengthOption { Name = "經常", Value = "4" },
                    new PantLengthOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            #region AnkleLengthPants(九分褲)
            response.AnkleLengthPants = new AnkleLengthPants
            {
                EnName = "AnkleLengthPants",
                ChiName = "九分褲",
                Options = new PantLengthOption[]
                {
                    new PantLengthOption { Name = "極少", Value = "1" },
                    new PantLengthOption { Name = "很少", Value = "2" },
                    new PantLengthOption { Name = "有時", Value = "3" },
                    new PantLengthOption { Name = "經常", Value = "4" },
                    new PantLengthOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion

            #region FloorPants(落地褲)
            response.FloorPants = new FloorPants
            {
                EnName = "FloorPants",
                ChiName = "落地褲",
                Options = new PantLengthOption[]
                {
                    new PantLengthOption { Name = "極少", Value = "1" },
                    new PantLengthOption { Name = "很少", Value = "2" },
                    new PantLengthOption { Name = "有時", Value = "3" },
                    new PantLengthOption { Name = "經常", Value = "4" },
                    new PantLengthOption { Name = "總是", Value = "5" }
                }.ToList()
            };
            #endregion


            return Task.FromResult(response);
        }
    }
}
