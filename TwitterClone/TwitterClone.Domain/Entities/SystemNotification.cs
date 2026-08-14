namespace TwitterClone.Domain.Entities
{
    public class SystemNotification : Notification
    {
        public Guid SystemNotificationByUserId { get; set; }

        public SystemNotification(Guid systemNotificationByUserId) : base("System")
        {
            SystemNotificationByUserId = systemNotificationByUserId;
        }
    }
}
