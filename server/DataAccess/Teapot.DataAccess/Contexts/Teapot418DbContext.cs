using Microsoft.EntityFrameworkCore;
using Teapot.Core.Entities.Concrete;
using Teapot.Entities.Concrete;

namespace Teapot.DataAccess.Contexts
{
    public class Teapot418DbContext : DbContext
    {
        public Teapot418DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectContributor> ProjectContributors { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ProjectFile> ProjectFiles { get; set; }
    }
}
