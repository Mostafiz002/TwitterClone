using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikesController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetLikes()
        {
            return Ok("Success");
        }

        [HttpGet("{id}")]
        public IActionResult GetLikeById(int id)
        {
            return Ok($"{id} found");
        }

        [HttpPost]
        public IActionResult CreateLike()
        {
            return Ok("Success");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateLike(int id)
        {
            return Ok($"{id} updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLike(int id)
        {
            return Ok($"{id} deleted");
        }
    }
}
