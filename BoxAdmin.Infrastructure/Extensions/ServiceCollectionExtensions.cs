using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Infrastructure.Contexts;

namespace BoxAdmin.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddScoped<IBoxDbContext>(provider => provider.GetService<BoxDbContext>());
            services.AddScoped<IBoxDbContext, BoxContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories
            // 用途不大
            #endregion Repositories
        }
    }
}
