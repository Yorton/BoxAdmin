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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_1
{
    public class GetQuestion1Query : IRequest<GetQuestion1Response>
    {
    }

    public class GetQuestion1QueryHandler : IRequestHandler<GetQuestion1Query, GetQuestion1Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion1QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<GetQuestion1Response> Handle(GetQuestion1Query command, CancellationToken cancellationToken)
        {
            GetQuestion1Response response = new GetQuestion1Response();

            response.LevelType = "Style"; //風格
            response.QuestionName = "這是你喜歡的風格嗎?";

            //文件未定義題目名稱
            string[] Names = new string[] { "", "", "", "", "", "", "", "", "",
                                            "", "", "", "", "", "", "", "", ""};

            for (int i = 1; i <= 18; i++) 
            {
                response.Questions.Add(new Question
                {
                    No = i.ToString(),
                    Name = Names[i-1],
                    Options = new StyleOption[]
                   {
                    new StyleOption { EnName = "Dislike", ChiName = "不喜歡", Value = "1"},
                    new StyleOption { EnName = "Normal", ChiName = "普通", Value = "3"},
                    new StyleOption { EnName = "Like", ChiName = "喜歡", Value = "5"}
                   }.ToList()
                });
            }

            return await Task.FromResult(response);
        }
    }
}
