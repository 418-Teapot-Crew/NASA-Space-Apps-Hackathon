using Teapot.Core.Entities.Abstract;

namespace Teapot.Entities.Concrete
{
    public class ProjectContributor : IEntity
    {

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ContributorId { get; set; }
        public AppUser Contributor { get; set; }
        public Project Project { get; set; }
    }
}
