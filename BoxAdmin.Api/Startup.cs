using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using BoxAdmin.Infrastructure.Extensions;
using BoxAdmin.Application.Extensions;
using BoxAdmin.Api.Extensions;
using BoxAdmin.Api.Middlewares;

namespace BoxAdmin.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddHttpClient("iSheboxRecommended", client => 
            {
                client.BaseAddress = new Uri("https://apih.obdesign.com.tw/");
            });
            services.AddHttpContextAccessor();
            services.AddApplicationLayer();
            services.AddContextInfrastructure(Configuration);
            services.AddPersistenceContexts(Configuration);
            services.AddSharedInfrastructure(Configuration);
            services.AddEssentials();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc(o => { });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.ConfigureSwagger();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Run(ctx =>
            {
                ctx.Response.Redirect("/swagger/index.html"); //可以支持虛擬路徑或者index.html這類起始頁.
                return Task.FromResult(0);
            });
        }
    }
}
