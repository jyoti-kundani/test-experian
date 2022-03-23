using Microsoft.Extensions.DependencyInjection;
using Test.API.Services;

namespace Test.API.Extensions
{
    /// <summary>
    /// This class contains Extension methods on IServiceCollection, to configure services in starup.cs
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {           
            services.AddScoped<IHttpClientServiceProvider, HttpClientServiceProvider>();
            services.AddScoped<ITestService, TestService>();
            return services;
        }
    }
}
