using Teapot.Core.Entity.Abstract;

namespace Teapot.Entities.Concrete
{
    public class ProjectContributor : IEntity
    {

        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string ContributorId { get; set; }
        public User Contributor { get; set; }
        public Project Project { get; set; }
    }
}
