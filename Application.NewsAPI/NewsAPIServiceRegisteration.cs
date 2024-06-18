using Application.Business_Logic.Contracts;
using Application.NewsService.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewsAPI
{
    public static  class NewsAPIServiceRegisteration
    {
        public static IServiceCollection AddNewsAPIServices(this IServiceCollection services)
        {
            
            services.AddScoped<INewsService, Services.NewsService>();

            return services;
        }
    }
}

