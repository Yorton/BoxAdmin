using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MediatR;

namespace BoxAdmin.Application.Test.Features
{
    using MatchingMakersFeatureCommands = BoxAdmin.Application.Features.MatchingMakers.Commands;

    public class MatchingMakersTests
    {
        private readonly IMediator _mediator;

        public MatchingMakersTests(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Fact]
        //public async Task MatchingMakersFeature_ImageSubmit_ShouldReturns_ImageUrl()
        //{
        //}
    }
}
