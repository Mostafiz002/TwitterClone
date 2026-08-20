namespace TwitterClone.Domain.Entities

{
    public class User : BaseEntity, INotifiable, IFollowable
    {
        public User(string email) : base(Guid.NewGuid())
        {
            Email = email;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private List<Guid> _followers = new List<Guid>();
        private List<Guid> _incomingNotifications = new List<Guid>();

        public void Follow(Guid userId)
        {
            if (!_followers.Contains(userId))
            {
                _followers.Add(userId);
            }
        }
        public void Unfollow(Guid userId)
        {
            if (_followers.Contains(userId))
            {
                _followers.Remove(userId);
            }
        }
        public void AddNotification(Guid notificationId)
        {
            if (!_incomingNotifications.Contains(notificationId))
            {
                _incomingNotifications.Add(notificationId);
            }
        }
    }
}
