namespace TwitterClone.Domain.Entities
{
    public class MensionNotification : Notification
    {
        public MensionNotification(Guid mensionByUserId) : base("Mension")
        {
            MensionByUserId = mensionByUserId;
        }
        public Guid MensionByUserId { get; set; }
        public override string DescribeRecords()
        {
            var baseRecords = base.DescribeRecords();
            return $"{baseRecords} -- Notification Type: {Type}, Mension By User Id: {MensionByUserId}, Created At: {CreatedAt}";
        }
        public override string GetMessage()
        {
            return $"User with ID {MensionByUserId} mentioned you in a post.";
        }
    }
}
