using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UrlShortener.Application
{
    public static class UrlShortenerApplicationModule
    {
        public static IServiceCollection AddIOCApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());


            return services;

        }
    }
}
