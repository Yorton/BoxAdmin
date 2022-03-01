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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_7
{
    public class GetQuestion7Query : IRequest<GetQuestion7Response>
    {
    }

    public class GetQuestion7QueryHandler : IRequestHandler<GetQuestion7Query, GetQuestion7Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion7QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion7Response> Handle(GetQuestion7Query command, CancellationToken cancellationToken)
        {
            GetQuestion7Response response = new GetQuestion7Response();

            response.LevelType = "Body Shape"; //身形
            response.QuestionName = "請填入平常的購衣尺碼(複選，最多兩項)";

            #region TopClothes(上衣)
            response.TopClothes = new TopClothes
            {
                EnName = "TopClothes",
                ChiName = "上衣",
                Options = new string[] { "S", "M", "L", "XL", "2L", "3L", "4L", "5L" }.ToList()
            };
            #endregion

            #region Bottoms(下著)
            response.Bottoms = new Bottoms
            {
                EnName = "Bottoms",
                ChiName = "下著",
                Options = new string[] { "S", "M", "L", "XL", "2L", "3L", "4L", "5L" }.ToList()
            };
            #endregion

            #region Jeans(牛仔褲)
            response.Jeans = new Jeans
            {
                EnName = "Jeans",
                ChiName = "牛仔褲(吋)",
                Options = new string[] { "22", "24", "26", "28", "30", "32", "34", "34", "38", "40", "42", "44" }.ToList()
            };
            #endregion

            #region Dress(洋裝)
            response.Dress = new Dress
            {
                EnName = "Dress",
                ChiName = "洋裝",
                Options = new string[] { "S", "M", "L", "XL", "2L", "3L", "4L", "5L" }.ToList()
            };
            #endregion

            #region Brassier(內衣)
            response.Brassier = new Brassier
            {
                EnName = "Brassier",
                ChiName = "內衣(吋)",
                BraOptions = new string[] { "A", "B", "C", "D", "E", "F" }.ToList(),
                SizeOptions = new string[] { "30", "32", "34", "36", "38", "40", "42" }.ToList(),
            };
            #endregion

            return Task.FromResult(response);
        }
    }
}
