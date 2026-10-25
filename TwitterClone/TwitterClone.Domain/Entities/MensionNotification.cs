namespace TwitterClone.Domain.Entities
{
    public class MensionNotification : Notification
    {
        public Guid MensionByUserId { get; set; }

        public MensionNotification(Guid mensionByUserId)
            : base("Mension")
        {
            MensionByUserId = mensionByUserId;
        }

        public override string GetMessage()
        {
            return $"User with ID {MensionByUserId} mentioned you in a post.";
        }
    }
}