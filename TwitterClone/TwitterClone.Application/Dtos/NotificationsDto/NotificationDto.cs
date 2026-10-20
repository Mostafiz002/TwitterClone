namespace TwitterClone.Application.Dtos;

public class NotificationDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ActorUserId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
}