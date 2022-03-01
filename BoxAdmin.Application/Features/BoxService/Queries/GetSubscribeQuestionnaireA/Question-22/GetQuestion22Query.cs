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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_22
{
    public class GetQuestion22Query : IRequest<GetQuestion22Response>
    {
    }

    public class GetQuestion22QueryHandler : IRequestHandler<GetQuestion22Query, GetQuestion22Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion22QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion22Response> Handle(GetQuestion22Query command, CancellationToken cancellationToken)
        {
            GetQuestion22Response response = new GetQuestion22Response();

            response.LevelType = "Personal"; //個人
            response.QuestionName = "你目前從事什麼類型的工作?";

            #region Industry(產業)
            response.Industry = new Industry
            {
                EnName = "Industry",
                ChiName = "產業",
                Options = new JobOption[]
                {
                    new JobOption
                    {
                        Name = "餐飲",
                        Value = "101"
                    },
                    new JobOption
                    {
                        Name = "旅遊",
                        Value = "102"
                    },
                    new JobOption
                    {
                        Name = "食品",
                        Value = "103"
                    },
                    new JobOption
                    {
                        Name = "製造",
                        Value = "104"
                    },
                    new JobOption
                    {
                        Name = "顧問",
                        Value = "105"
                    },
                    new JobOption
                    {
                        Name = "科技",
                        Value = "106"
                    },
                    new JobOption
                    {
                        Name = "金融",
                        Value = "107"
                    },
                    new JobOption
                    {
                        Name = "藝術",
                        Value = "108"
                    },
                    new JobOption
                    {
                        Name = "廣告",
                        Value = "109"
                    },
                    new JobOption
                    {
                        Name = "運輸",
                        Value = "110"
                    },
                    new JobOption
                    {
                        Name = "零售",
                        Value = "111"
                    },
                    new JobOption
                    {
                        Name = "軍公教",
                        Value = "112"
                    },
                    new JobOption
                    {
                        Name = "醫療",
                        Value = "113"
                    },
                    new JobOption
                    {
                        Name = "學生",
                        Value = "114"
                    },
                    new JobOption
                    {
                        Name = "其他",
                        Value = "199"
                    }
                }.ToList()
            };
            #endregion

            #region Competency(職能)
            response.Competency = new Competency
            {
                EnName = "Competency",
                ChiName = "職能",
                Options = new JobOption[]
                {
                        new JobOption
                        {
                            Name = "財會",
                            Value = "201"
                        },
                        new JobOption
                        {
                            Name = "研發",
                            Value = "202"
                        },
                        new JobOption
                        {
                            Name = "行銷",
                            Value = "203"
                        },
                        new JobOption
                        {
                            Name = "人資",
                            Value = "204"
                        },
                        new JobOption
                        {
                            Name = "設計",
                            Value = "205"
                        },
                        new JobOption
                        {
                            Name = "資訊",
                            Value = "206"
                        },
                        new JobOption
                        {
                            Name = "門市",
                            Value = "207"
                        },
                        new JobOption
                        {
                            Name = "總務",
                            Value = "208"
                        },
                        new JobOption
                        {
                            Name = "學生",
                            Value = "209"
                        },
                        new JobOption
                        {
                            Name = "其他",
                            Value = "299"
                        }
                }.ToList()
            };
            #endregion

            #region Management(管理職)
            response.Management = new Management
            {
                EnName = "Management",
                ChiName = "管理職",
                Options = new JobOption[]
               {
                        new JobOption
                        {
                            Name = "是",
                            Value = "1"
                        },
                        new JobOption
                        {
                            Name = "否",
                            Value = "0"
                        }
               }.ToList()
            };
            #endregion

            return Task.FromResult(response);
        }
    }
}
