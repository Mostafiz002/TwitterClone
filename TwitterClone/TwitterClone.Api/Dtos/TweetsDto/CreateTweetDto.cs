namespace TwitterClone.Api.Dtos.TweetsDto
{
    public class CreateTweetDto
    {
        public required string Content { get; set; }
        public required Guid UserId { get; set; }
    }
}
