namespace TwitterClone.Domain.Entities

{
    public class Message
    {
        public Guid Id { get; private set; }
        public Guid SenderId { get; }
        public Guid ReceiverId { get; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; }

        public Message(Guid senderid, Guid receiverid)
        {
            Id = Guid.NewGuid();
            SenderId = senderid;
            ReceiverId = receiverid;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
