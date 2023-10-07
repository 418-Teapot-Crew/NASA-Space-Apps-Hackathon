using Teapot.Core.Entity.Abstract;

namespace Teapot.Entities.Concrete
{
    public class Message : IEntity
    {

        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public User Sender { get; set; }

    }
}
