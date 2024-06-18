using Application.Business_Logic.Contracts;
using Application.DAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL
{
    public static class DALServiceRegisteration
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationNews"),
                b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName));
            });
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            return services;
        }
    }
}
