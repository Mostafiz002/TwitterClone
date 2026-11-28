namespace TwitterClone.Domain.Entities
{
    public class Bookmark : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TweetId { get; set; }

        public Bookmark() : base(Guid.NewGuid())
        {
        }
    }
}
