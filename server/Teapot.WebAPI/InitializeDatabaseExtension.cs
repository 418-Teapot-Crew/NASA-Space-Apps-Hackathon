using Microsoft.EntityFrameworkCore;
using Teapot.DataAccess.Contexts;

namespace Teapot.WebAPI
{
    public static class InitializeDatabaseExtension
    {
        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var baseDbContext = scope.ServiceProvider.GetRequiredService<Teapot418DbContext>();
                baseDbContext.Database.Migrate();
            }
        }
    }
}