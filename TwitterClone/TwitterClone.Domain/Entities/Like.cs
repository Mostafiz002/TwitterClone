namespace TwitterClone.Domain.Entities
{
    public class Like : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }

        public Like(Guid userId, Guid tweetId) : base(Guid.NewGuid())
        {
            UserId = userId;
            TweetId = tweetId;
        }
    }
}