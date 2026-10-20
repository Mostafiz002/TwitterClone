namespace TwitterClone.Application.Dtos;

public class CreateNotificationDto
{
    public Guid UserId { get; set; }
    public Guid ActorUserId { get; set; }
    public string Type { get; set; } = string.Empty;
}