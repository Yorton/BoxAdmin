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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_17
{
    public class GetQuestion17Query : IRequest<GetQuestion17Response>
    {
    }

    public class GetQuestion17QueryHandler : IRequestHandler<GetQuestion17Query, GetQuestion17Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion17QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion17Response> Handle(GetQuestion17Query command, CancellationToken cancellationToken)
        {
            GetQuestion17Response response = new GetQuestion17Response();
            
            response.LevelType = "Habit"; //習慣
            response.QuestionName = "各項單品可接受的價位大概落在多少(NTD)?";

            #region TopClothes(上衣)
            response.TopClothes = new TopClothesPrice
            {
                EnName = "TopClothes",
                ChiName = "上衣",
                Options = new PriceOption[]
                {
                    new PriceOption { Name = "$500以下", Value = "1" },
                    new PriceOption { Name = "$500~$800", Value = "2" },
                    new PriceOption { Name = "$800~$1200", Value = "3" },
                    new PriceOption { Name = "$1200~$1500", Value = "4" },
                    new PriceOption { Name = "$1500以上", Value = "5" }
                }.ToList()
            };
            #endregion

            #region Bottoms(下身)
            response.Bottoms = new BottomsPrice
            {
                EnName = "Bottoms",
                ChiName = "下身",
                Options = new PriceOption[]
                {
                    new PriceOption { Name = "$500以下", Value = "1" },
                    new PriceOption { Name = "$500~$800", Value = "2" },
                    new PriceOption { Name = "$800~$1200", Value = "3" },
                    new PriceOption { Name = "$1200~$1500", Value = "4" },
                    new PriceOption { Name = "$1500以上", Value = "5" }
                }.ToList()
            };
            #endregion

            #region Dress(洋裝)
            response.Dress = new DressPrice
            {
                EnName = "Dress",
                ChiName = "洋裝",
                Options = new PriceOption[]
                {
                    new PriceOption { Name = "$500以下", Value = "1" },
                    new PriceOption { Name = "$500~$800", Value = "2" },
                    new PriceOption { Name = "$800~$1200", Value = "3" },
                    new PriceOption { Name = "$1200~$1500", Value = "4" },
                    new PriceOption { Name = "$1500以上", Value = "5" }
                }.ToList()
            };
            #endregion

            #region Outerwear(外套)
            response.Outerwear = new OuterwearPrice
            {
                EnName = "Outerwear",
                ChiName = "外套",
                Options = new PriceOption[]
                {
                    new PriceOption { Name = "$500以下", Value = "1" },
                    new PriceOption { Name = "$500~$800", Value = "2" },
                    new PriceOption { Name = "$800~$1200", Value = "3" },
                    new PriceOption { Name = "$1200~$1500", Value = "4" },
                    new PriceOption { Name = "$1500以上", Value = "5" }
                }.ToList()
            };
            #endregion

            #region Accessory(飾品)
            response.Accessory = new AccessoryPrice
            {
                EnName = "Accessory",
                ChiName = "飾品",
                Options = new PriceOption[]
                {
                    new PriceOption { Name = "$500以下", Value = "1" },
                    new PriceOption { Name = "$500~$800", Value = "2" },
                    new PriceOption { Name = "$800~$1200", Value = "3" },
                    new PriceOption { Name = "$1200~$1500", Value = "4" },
                    new PriceOption { Name = "$1500以上", Value = "5" }
                }.ToList()
            };
            #endregion

            return Task.FromResult(response);
        }
    }
}
