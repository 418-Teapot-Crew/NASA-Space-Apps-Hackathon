using Teapot.Core.Entity.Abstract;

namespace Teapot.Entities.Concrete
{
    public class Chat : IEntity
    {
        public int Id { get; set; }
        public int ProjectOwnerId { get; set; }
        public int ContributerId { get; set; }
        public User ProjectOwner { get; set; }
        public User Contributer { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
