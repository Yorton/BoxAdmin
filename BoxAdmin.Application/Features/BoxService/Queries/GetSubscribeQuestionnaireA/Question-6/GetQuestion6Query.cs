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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_6
{
    public class GetQuestion6Query : IRequest<GetQuestion6Response>
    {
    }

    public class GetQuestion6QueryHandler : IRequestHandler<GetQuestion6Query, GetQuestion6Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion6QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion6Response> Handle(GetQuestion6Query command, CancellationToken cancellationToken)
        {
            GetQuestion6Response response = new GetQuestion6Response();

            response.LevelType = "Body Shape"; //身形
            response.QuestionName = "你的身形尺寸";

            response.BodySizeNameList.Add(new BodySizeName { EnName = "ShoulderWidth", ChiName = "肩寬" });
            response.BodySizeNameList.Add(new BodySizeName { EnName = "Bust", ChiName = "胸圍" });
            response.BodySizeNameList.Add(new BodySizeName { EnName = "WaistCircumference", ChiName = "腰圍" });
            response.BodySizeNameList.Add(new BodySizeName { EnName = "HipCircumference", ChiName = "臀圍" });
            response.BodySizeNameList.Add(new BodySizeName { EnName = "ThighCircumference", ChiName = "大腿圍" });

            return Task.FromResult(response);
        }
    }
}
