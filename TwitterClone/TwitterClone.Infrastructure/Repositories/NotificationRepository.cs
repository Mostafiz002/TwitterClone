using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly List<Notification> _notifications = new();

    public Notification AddNotification(Notification notification)
    {
        _notifications.Add(notification);
        return notification;
    }

    public List<Notification> GetNotifications()
    {
        return _notifications;
    }

    public Notification? GetNotificationById(Guid id)
    {
        return _notifications.FirstOrDefault(n => n.Id == id);
    }

    public bool DeleteNotification(Guid id)
    {
        var notification = GetNotificationById(id);

        if (notification is null)
            return false;

        return _notifications.Remove(notification);
    }
}