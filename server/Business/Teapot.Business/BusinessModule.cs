using Microsoft.Extensions.DependencyInjection;
using Teapot.Business.Concrete.Auths;
using Teapot.Business.Concrete.Chats;
using Teapot.Business.Concrete.Messages;
using Teapot.Business.Concrete.ProjectContributors;
using Teapot.Business.Concrete.Projects;
using Teapot.Business.Concrete.Users;

namespace Teapot.Business
{
    public static class BusinessModule
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IProjectService, ProjectManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IChatService, ChatManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IProjectContributorService, ProjectContributorManager>();


            return services;
        }
    }
}
