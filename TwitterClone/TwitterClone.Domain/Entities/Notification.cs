namespace TwitterClone.Domain.Entities
{
     class Notification
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; }
        public string Content { get; set; }
        public bool IsRead{ get; set; }
        public DateTime CreatedAt { get; }

        public Notification(Guid userid)
        {
            Id = Guid.NewGuid();
            UserId = userid;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
