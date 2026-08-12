namespace TwitterClone.Domain.Entities
{
    internal class Bookmark
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; }
        public Guid TweetId { get; }
        public DateTime CreatedAt { get; }

        public Bookmark(Guid userid, Guid tweetid)
        {
            Id = Guid.NewGuid();
            UserId = userid;
            TweetId = tweetid;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
