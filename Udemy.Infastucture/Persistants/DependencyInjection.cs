using AutoService.Application.Abstractions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Infastucture.Persistants;

namespace AutoService.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAppDbContext,AppDbContext>(options =>
                options.UseLazyLoadingProxies()

                        .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            
            return services;
        }
    }
}
