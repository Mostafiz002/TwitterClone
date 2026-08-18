namespace TwitterClone.Domain.Entities
{
    public class FriendRequestNotification : Notification
    {
        public Guid FriendRequestByUserId { get; set; }

        public FriendRequestNotification(Guid friendRequestByUserId) : base("FriendRequest")
        {
            FriendRequestByUserId = friendRequestByUserId;
        }

        public override string GetMessage()
        {
            return $"Friend request from user with ID {FriendRequestByUserId}.";
        }
    }
}
