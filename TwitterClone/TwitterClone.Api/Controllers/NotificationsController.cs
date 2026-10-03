using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetNotifications()
        {
            return Ok("Success");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationById(int id)
        {
            return Ok($"{id} found");
        }

        [HttpPost]
        public IActionResult CreateNotification()
        {
            return Ok("Success");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateNotification(int id)
        {
            return Ok($"{id} updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            return Ok($"{id} deleted");
        }
    }
}
