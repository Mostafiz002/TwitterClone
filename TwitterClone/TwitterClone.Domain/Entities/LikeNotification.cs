namespace TwitterClone.Domain.Entities
{
    public class LikeNotification : Notification
    {
        public LikeNotification(Guid likeByUserId) : base("Like")
        {
            LikeByUserId = likeByUserId;
        }
        public Guid LikeByUserId { get; set; }

        public override string DescribeRecords()
        {
            var baseRecords = base.DescribeRecords();
            return $"{baseRecords} -- Notification Type: {Type}, Like By User Id: {LikeByUserId}, Created At: {CreatedAt}";
        }
    }
}
