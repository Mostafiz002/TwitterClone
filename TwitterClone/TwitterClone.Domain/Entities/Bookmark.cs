namespace TwitterClone.Domain.Entities
{
    internal class Bookmark : BaseEntity
    {
        public Guid UserId { get; }
        public Guid TweetId { get; }

        public Bookmark(Guid userid, Guid tweetid) : base(Guid.NewGuid())
        {
            UserId = userid;
            TweetId = tweetid;
        }
    }
}
