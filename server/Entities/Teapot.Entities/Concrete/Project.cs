using Teapot.Core.Entities.Abstract;

namespace Teapot.Entities.Concrete
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public DateTime Date { get; set; }
        public string  ProjectUrl { get; set; }
        public string? ImageUrl { get; set; }
        public bool Status { get; set; }
        public ICollection<ProjectContributor> Contributors { get; set; }
    }
}

