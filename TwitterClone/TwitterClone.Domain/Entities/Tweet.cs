namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikable
    {
        private string Content { get; set; }
        private Guid UserId { get; set; }

        public static int MaxContentLength = 280; // static property for max content length

        public Tweet(string content, Guid userId) : base(Guid.NewGuid()) // constructor chaining
        {
            Content = content; // required field
            UserId = userId; // required field
        }
        public bool CanBeLiked()
        {
            return true;
        }
    }
}
