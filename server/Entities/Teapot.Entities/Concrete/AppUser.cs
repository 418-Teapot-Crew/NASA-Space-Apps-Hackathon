using Teapot.Core.Entities.Concrete;

namespace Teapot.Entities.Concrete
{
    public class AppUser : User
    {
        public ICollection<ProjectContributor> Projects { get; set; }
        public string? Description { get; set; }
    }
}
