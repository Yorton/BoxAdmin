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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_21
{
    public class GetQuestion21Query : IRequest<GetQuestion21Response>
    {
    }

    public class GetQuestion21QueryHandler : IRequestHandler<GetQuestion21Query, GetQuestion21Response>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetQuestion21QueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public Task<GetQuestion21Response> Handle(GetQuestion21Query command, CancellationToken cancellationToken)
        {
            GetQuestion21Response response = new GetQuestion21Response();

            response.LevelType = "Personal"; //個人
            response.QuestionName = "你的生日";

            return Task.FromResult(response);
        }
    }
}
