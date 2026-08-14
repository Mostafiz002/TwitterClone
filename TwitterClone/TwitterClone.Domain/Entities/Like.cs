namespace TwitterClone.Domain.Entities
{
    public class Like : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
        public string Content { get; set; }

        public Like() : base(Guid.NewGuid())
        {
            UserId = Guid.NewGuid();
            TweetId = Guid.NewGuid();
        }
    }
}