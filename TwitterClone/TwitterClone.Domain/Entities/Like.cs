namespace TwitterClone.Domain.Entities
{
    public class Like : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TweetId { get; set; }

        public Like() : base(Guid.NewGuid())
        {
          
        }
    }
}