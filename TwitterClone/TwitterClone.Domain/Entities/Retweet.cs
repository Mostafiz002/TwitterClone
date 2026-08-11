namespace TwitterClone.Domain.Entities;

public class Retweet
{
    public Guid Id { get; private set; }
    public Guid UserId { get; }
    public Guid TweetId { get; }
    public DateTime RetweetedAt { get; }

    public Retweet(Guid userid, Guid tweetid)
    {
        Id = Guid.NewGuid();
        UserId = userid;
        TweetId = tweetid;
        RetweetedAt = DateTime.UtcNow;
    }
}