namespace TwitterClone.Domain.Entities
{
    public class CommentNotification : Notification
    {
        public Guid CommentByUserId { get; set; }

        public CommentNotification(Guid commentByUserId)
            : base("Comment")
        {
            CommentByUserId = commentByUserId;
        }

        public override string GetMessage()
        {
            return $"Comment from user with ID {CommentByUserId}.";
        }
    }
}