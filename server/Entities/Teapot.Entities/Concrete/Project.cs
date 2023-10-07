using Teapot.Core.Entity.Abstract;

namespace Teapot.Entities.Concrete
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<ProjectContributor> Contributors { get; set; }
    }
}
