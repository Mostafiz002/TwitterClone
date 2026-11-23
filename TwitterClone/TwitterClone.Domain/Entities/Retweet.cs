namespace TwitterClone.Domain.Entities;

public class Retweet : BaseEntity
{
    public Guid UserId { get; }
    public Guid TweetId { get; }
    public string Comment { get; set; }   

    public Retweet(Guid userid, Guid tweetid) : base(Guid.NewGuid())
    {
        UserId = userid;
        TweetId = tweetid;
    }
}