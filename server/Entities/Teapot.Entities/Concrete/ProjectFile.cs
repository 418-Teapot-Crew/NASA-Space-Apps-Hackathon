using Teapot.Core.Entities.Abstract;

namespace Teapot.Entities.Concrete
{
    public class ProjectFile : IEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ImageUrl { get; set; }
    }
}
