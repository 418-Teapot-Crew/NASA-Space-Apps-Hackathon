namespace Teapot.Entities.Concrete
{
    public class ChatHistory
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        public int SenderId { get; set; }

        public int ReceiverId { get; set; }

        public string Message { get; set; }
        public AppUser Receiver { get; set; }
        public AppUser Sender { get; set; }
        public Project Project { get; set; }
    }
}
