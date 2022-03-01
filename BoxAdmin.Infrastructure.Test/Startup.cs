using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BoxAdmin.Application.Interfaces.Shared;
using BoxAdmin.Infrastructure.Shared.Services;

namespace BoxAdmin.Infrastructure.Test
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder
                //.ConfigureHostConfiguration(builder => builder.AddJsonFile("appsettings.json"))
                .ConfigureAppConfiguration((context, builder) => { });
        }

        public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
        {
            services.AddHttpClient();
            services.AddHttpClient("iSheboxRecommended", client =>
            {
                client.BaseAddress = new Uri("https://apih.obdesign.com.tw/");
            });
            services.AddTransient<IISheboxRecommendedService, ISheboxRecommendedService>();
        }
    }
}