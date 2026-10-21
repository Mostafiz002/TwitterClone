using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public IActionResult GetNotifications()
    {
        return Ok(_notificationService.GetNotifications());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetNotificationById(Guid id)
    {
        var notification = _notificationService.GetNotificationById(id);

        return notification is null ? NotFound() : Ok(notification);
    }

    [HttpPost]
    public IActionResult CreateNotification(CreateNotificationDto dto)
    {
        try
        {
            var notification = _notificationService.CreateNotification(dto);

            return CreatedAtAction(
                nameof(GetNotificationById),
                new { id = notification.Id },
                notification);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPatch("{id:guid}/read")]
    public IActionResult MarkAsRead(Guid id)
    {
        return _notificationService.MarkAsRead(id)
            ? NoContent()
            : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteNotification(Guid id)
    {
        return _notificationService.DeleteNotification(id)
            ? NoContent()
            : NotFound();
    }
}