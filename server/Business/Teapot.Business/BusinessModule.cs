using Microsoft.Extensions.DependencyInjection;

namespace Teapot.Business
{
    public static class BusinessModule
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            //services.AddScoped<>
            return services;
        }
    }
}
