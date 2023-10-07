using Microsoft.Extensions.DependencyInjection;
using Teapot.Business.Concrete.Auths;

namespace Teapot.Business
{
    public static class BusinessModule
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthManager>();
            return services;
        }
    }
}
