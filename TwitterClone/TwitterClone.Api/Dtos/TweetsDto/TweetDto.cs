namespace TwitterClone.Api.Dtos.TweetsDto
{
    public class TweetDto
    {
        public required string Id { get; set; }
        public required string Content { get; set; }
        public required string UserId { get; set; }
    }
}
