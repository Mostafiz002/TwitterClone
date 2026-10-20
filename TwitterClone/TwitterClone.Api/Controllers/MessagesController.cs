using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("user/{userId:guid}")]
        public IActionResult GetMessagesByUserId(Guid userId)
        {
            try
            {
                return Ok(_messageService.GetMessagesByUserId(userId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetMessageById(Guid id)
        {
            var message = _messageService.GetMessageById(id);

            return message is null ? NotFound() : Ok(message);
        }

        [HttpPost]
        public IActionResult SendMessage(CreateMessageDto dto)
        {
            try
            {
                var message = _messageService.SendMessage(dto);

                return CreatedAtAction(
                    nameof(GetMessageById),
                    new { id = message.Id },
                    message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{id:guid}/read")]
        public IActionResult MarkAsRead(Guid id)
        {
            return _messageService.MarkAsRead(id)
                ? NoContent()
                : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteMessage(Guid id)
        {
            return _messageService.DeleteMessage(id)
                ? NoContent()
                : NotFound();
        }
    }
}