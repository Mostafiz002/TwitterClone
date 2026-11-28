namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikable
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }

        public static int MaxContentLength = 280; // static property for max content length

        public Tweet() : base(Guid.NewGuid()) // constructor chaining
        {
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
