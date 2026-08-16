using TwitterClone.Domain.Entities;

var notifications = new List<Notification>()
{
    new FriendRequestNotification(Guid.NewGuid()),
    new CommentNotification(Guid.NewGuid()),
    new SystemNotification(),
    new LikeNotification(Guid.NewGuid()),
    new MensionNotification(Guid.NewGuid()),
};

foreach(var notification in notifications)
{
    Console.WriteLine(notification.GetMessage());
}