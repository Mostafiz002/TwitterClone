namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikable
    {
        public string Content { get; private set; }
        public Guid UserId { get; private set; }

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

        public void UpdateContent(string content)
        {
            Content = content;
        }
    }
}
