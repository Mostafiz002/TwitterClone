using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessages()
        {
            return Ok("Success");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            return Ok($"{id} found");
        }

        [HttpPost]
        public IActionResult CreateMessage()
        {
            return Ok("Success");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateMessage(int id)
        {
            return Ok($"{id} updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            return Ok($"{id} deleted");
        }
    }
}
