using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces;

public interface INotificationRepository
{
    Notification AddNotification(Notification notification);
    List<Notification> GetNotifications();
    Notification? GetNotificationById(Guid id);
    bool DeleteNotification(Guid id);
}