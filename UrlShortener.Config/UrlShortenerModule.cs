using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DataAccess.EFCore;
using UrlShortener.DataAccess.EFCore.Repository;
using UrlShortener.Domain.Model;

namespace UrlShortener.Config
{
    public static class UrlShortenerModule
    {
        public static IServiceCollection AddIOC(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConnectionString = configuration.GetConnectionString("UrlShortenerApiDB");

            services.AddDbContext<UrlShortenerDbContext>(options => options.UseSqlServer(databaseConnectionString));
            services.AddScoped<IUrlShortenerDbContext>(provider => provider.GetService<UrlShortenerDbContext>());

            services.AddTransient<IUrlShortenerRepository, UrlShortenerRepository>();
            services.AddTransient<IUrlShortenerHistoryRepository, UrlShortenerHistoryRepository>();


            return services;

        }
    }
}
