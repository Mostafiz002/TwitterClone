namespace TwitterClone.Application.Dtos
{
    public class CreateBookmarkDto
    {
        public Guid UserId { get; set; }
        public Guid TweetId { get; set; }
    }
}