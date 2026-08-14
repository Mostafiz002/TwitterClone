namespace TwitterClone.Domain.Entities

{
    public class Message : BaseEntity
    {
        public Guid SenderId { get; }
        public Guid ReceiverId { get; }
        public string Text { get; set; }

        public Message(Guid senderid, Guid receiverid) : base(Guid.NewGuid())
        {
            SenderId = senderid;
            ReceiverId = receiverid;
        }
    }
}
