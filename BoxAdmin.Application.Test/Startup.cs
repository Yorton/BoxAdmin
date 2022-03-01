using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BoxAdmin.Application.Extensions;
using BoxAdmin.Application.Interfaces.Shared;
using BoxAdmin.Infrastructure.Extensions;
using BoxAdmin.Infrastructure.Contexts;

namespace BoxAdmin.Application.Test
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder
                .ConfigureHostConfiguration(builder => builder.AddJsonFile("appsettings.json"))
                .ConfigureAppConfiguration((context, builder) => { });
        }

        public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
        {
            services.AddApplicationLayer();

            services.AddDbContext<BoxContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "MemoryDatabase");
            });

            services.AddPersistenceContexts(context.Configuration);

            services.AddTransient<IAuthenticatedUserService, FakeAuthenticatedUserService>();
        }
    }

    public class FakeAuthenticatedUserService : IAuthenticatedUserService
    {
        public string UserId { get; }
        public string Username { get; }
        public FakeAuthenticatedUserService()
        {
            this.UserId = "BOT";
            this.Username = "BOT";
        }
    }
}
