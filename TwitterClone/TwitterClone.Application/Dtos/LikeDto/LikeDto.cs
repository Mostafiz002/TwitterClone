namespace TwitterClone.Application.Dtos
{
    public class LikeDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TweetId { get; set; }
    }
}