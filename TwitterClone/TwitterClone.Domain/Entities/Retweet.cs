namespace TwitterClone.Domain.Entities;

public class Retweet : BaseEntity
{
    public Guid UserId { get; }
    public Guid TweetId { get; }
    public DateTime RetweetedAt { get; }

    public Retweet(Guid userid, Guid tweetid) : base(Guid.NewGuid())
    {
        UserId = userid;
        TweetId = tweetid;
    }
}