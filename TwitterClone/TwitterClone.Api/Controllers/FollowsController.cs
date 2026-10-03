using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFollows()
        {
            return Ok("Success");
        }

        [HttpGet("{id}")]
        public IActionResult GetFollowById(int id)
        {
            return Ok($"{id} found");
        }

        [HttpPost]
        public IActionResult CreateFollow()
        {
            return Ok("Success");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateFollow(int id)
        {
            return Ok($"{id} updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFollow(int id)
        {
            return Ok($"{id} deleted");
        }
    }
}
