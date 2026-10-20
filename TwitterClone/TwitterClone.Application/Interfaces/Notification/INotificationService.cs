using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces;

public interface INotificationService
{
    NotificationDto CreateNotification(CreateNotificationDto dto);
    List<NotificationDto> GetNotifications();
    NotificationDto? GetNotificationById(Guid id);
    bool MarkAsRead(Guid id);
    bool DeleteNotification(Guid id);
}