using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _repository;

    public NotificationService(INotificationRepository repository)
    {
        _repository = repository;
    }

    public NotificationDto CreateNotification(CreateNotificationDto dto)
    {
        Notification notification = dto.Type.ToLowerInvariant() switch
        {
            "like" => new LikeNotification(dto.ActorUserId),
            "comment" => new CommentNotification(dto.ActorUserId),
            "mension" => new MensionNotification(dto.ActorUserId),
            "friendrequest" => new FriendRequestNotification(dto.ActorUserId),
            "system" => new SystemNotification
            {
                SystemNotificationByUserId = dto.ActorUserId
            },
            _ => throw new ArgumentException("Invalid notification type.")
        };

        notification.UserId = dto.UserId;

        _repository.AddNotification(notification);

        return MapToDto(notification);
    }

    public List<NotificationDto> GetNotifications()
    {
        return _repository.GetNotifications()
            .Select(MapToDto)
            .ToList();
    }

    public NotificationDto? GetNotificationById(Guid id)
    {
        var notification = _repository.GetNotificationById(id);

        return notification is null ? null : MapToDto(notification);
    }

    public bool MarkAsRead(Guid id)
    {
        var notification = _repository.GetNotificationById(id);

        if (notification is null)
            return false;

        notification.IsRead = true;
        return true;
    }

    public bool DeleteNotification(Guid id)
    {
        return _repository.DeleteNotification(id);
    }

    private static NotificationDto MapToDto(Notification notification)
    {
        var actorUserId = notification switch
        {
            LikeNotification n => n.LikeByUserId,
            CommentNotification n => n.CommentByUserId,
            MensionNotification n => n.MensionByUserId,
            FriendRequestNotification n => n.FriendRequestByUserId,
            SystemNotification n => n.SystemNotificationByUserId,
            _ => Guid.Empty
        };

        return new NotificationDto
        {
            Id = notification.Id,
            UserId = notification.UserId,
            ActorUserId = actorUserId,
            Type = notification.Type,
            Message = notification.GetMessage(),
            IsRead = notification.IsRead
        };
    }
}