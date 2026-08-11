namespace TwitterClone.Domain.Entities
{
    public class Like
    {
        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; }

        public Like()
        {
            UserId = Guid.NewGuid();
            TweetId = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}