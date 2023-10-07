using Teapot.Core.Entities.Abstract;

namespace Teapot.Entities.Concrete
{
    public class Chat : IEntity
    {
        public int Id { get; set; }
        public int ProjectOwnerId { get; set; }
        public int ContributerId { get; set; }
        public AppUser ProjectOwner { get; set; }
        public AppUser Contributer { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}
