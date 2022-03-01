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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_2
{
                                                    
    public class GetQuestion2Query : IRequest<GetQuestion2Response>
    {
    }

    public  class GetQuestion2QueryHandler : IRequestHandler<GetQuestion2Query, GetQuestion2Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion2QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<GetQuestion2Response> Handle(GetQuestion2Query command, CancellationToken cancellationToken)
        {
            GetQuestion2Response response = new GetQuestion2Response();

            response.LevelType = "Style"; //風格
            response.QuestionName = "你會購買哪些品牌的服裝呢?(複選)";

            response.Options.Add(new BrandOption { Value = "1", Name = "Agnes b." });
            response.Options.Add(new BrandOption { Value = "2", Name = "Airspace" });
            response.Options.Add(new BrandOption { Value = "3", Name = "AllSaint" });
            response.Options.Add(new BrandOption { Value = "4", Name = "CHUU" });
            response.Options.Add(new BrandOption { Value = "5", Name = "GUCCI" });
            response.Options.Add(new BrandOption { Value = "6", Name = "Guess" });
            response.Options.Add(new BrandOption { Value = "7", Name = "H&M" });
            response.Options.Add(new BrandOption { Value = "8", Name = "JENDES" });
            response.Options.Add(new BrandOption { Value = "9", Name = "Joyrich" });
            response.Options.Add(new BrandOption { Value = "10", Name = "Lativ" });
            response.Options.Add(new BrandOption { Value = "11", Name = "LOVFEE" });
            response.Options.Add(new BrandOption { Value = "12", Name = "MANGO" });
            response.Options.Add(new BrandOption { Value = "13", Name = "Marjorie" });
            response.Options.Add(new BrandOption { Value = "14", Name = "MaxMara" });
            response.Options.Add(new BrandOption { Value = "15", Name = "Mercci 22" });
            response.Options.Add(new BrandOption { Value = "16", Name = "Naturally JOJO" });
            response.Options.Add(new BrandOption { Value = "17", Name = "NET" });
            response.Options.Add(new BrandOption { Value = "18", Name = "OB嚴選" });
            response.Options.Add(new BrandOption { Value = "19", Name = "Pull&Bear" });
            response.Options.Add(new BrandOption { Value = "20", Name = "SHEIN" });
            response.Options.Add(new BrandOption { Value = "21", Name = "Stussy" });
            response.Options.Add(new BrandOption { Value = "22", Name = "Tommy" });
            response.Options.Add(new BrandOption { Value = "23", Name = "Uniqlo" });
            response.Options.Add(new BrandOption { Value = "24", Name = "ZARA" });
            response.Options.Add(new BrandOption { Value = "25", Name = "無印良品" });

            return await Task.FromResult(response);
        }
    }
}
