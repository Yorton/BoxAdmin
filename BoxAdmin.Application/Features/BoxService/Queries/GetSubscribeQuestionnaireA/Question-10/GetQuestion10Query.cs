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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_10
{
    public class GetQuestion10Query : IRequest<GetQuestion10Response>
    {
    }

    public class GetQuestion10QueryHandler : IRequestHandler<GetQuestion10Query, GetQuestion10Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion10QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion10Response> Handle(GetQuestion10Query command, CancellationToken cancellationToken)
        {
            GetQuestion10Response response = new GetQuestion10Response();

            response.LevelType = "Body Shape"; //身形
            response.QuestionName = "想要修飾的部位?(複選)";

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Shoulder",
                ChiName = "肩膀",
                Options = new FlatterPartOption[] { new FlatterPartOption { No = "1", Name = "寬"}
                                                  , new FlatterPartOption { No = "2", Name = "窄"} }.ToList()
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Face",
                ChiName = "臉部",
                Options = new FlatterPartOption[] { new FlatterPartOption { No = "1", Name = "圓"}
                                                  , new FlatterPartOption { No = "2", Name = "方"}
                                                  , new FlatterPartOption { No = "3", Name = "長"}}.ToList()
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Arm",
                ChiName = "手臂"
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Neck",
                ChiName = "脖子",
                Options = new FlatterPartOption[] { new FlatterPartOption { No = "1", Name = "短"}
                                                  , new FlatterPartOption { No = "2", Name = "粗"} }.ToList()
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Back",
                ChiName = "背部",
                Options = new FlatterPartOption[] { new FlatterPartOption { No = "1", Name = "厚"}
                                                  , new FlatterPartOption { No = "2", Name = "膚況差"} }.ToList()
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Chest",
                ChiName = "胸部",
                Options = new FlatterPartOption[] { new FlatterPartOption { No = "1", Name = "大"}
                                                  , new FlatterPartOption { No = "2", Name = "小"} }.ToList()
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Loins",
                ChiName = "腰部",
                Options = new FlatterPartOption[] { new FlatterPartOption { No = "1", Name = "有曲線"}
                                                  , new FlatterPartOption { No = "2", Name = "無曲線"} }.ToList()
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Belly",
                ChiName = "腹部"
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Hip",
                ChiName = "臀部",
                Options = new FlatterPartOption[] { new FlatterPartOption { No = "1", Name = "扁"}
                                                  , new FlatterPartOption { No = "2", Name = "圓"} }.ToList()
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "HipBone",
                ChiName = "髖部",
                Options = new FlatterPartOption[] { new FlatterPartOption { No = "1", Name = "寬"}
                                                  , new FlatterPartOption { No = "2", Name = "窄"} }.ToList()
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Leg",
                ChiName = "腿"
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Thigh",
                ChiName = "大腿"
            });

            response.BodyPartList.Add(new BodyPart
            {
                EnName = "Shank",
                ChiName = "小腿"
            });

            return Task.FromResult(response);
        }
    }
}
