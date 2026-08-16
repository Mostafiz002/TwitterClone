namespace TwitterClone.Domain.Entities
{
    public class SystemNotification : Notification
    {
        public Guid SystemNotificationByUserId { get; set; }

        public SystemNotification() : base("System")
        {
        }

        public override string GetMessage()
        {
            return $"System notification from user with ID {SystemNotificationByUserId}.";
        }
    }
}
