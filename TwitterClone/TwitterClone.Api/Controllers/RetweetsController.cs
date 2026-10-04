using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RetweetsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRetweets()
        {
            return Ok("Success");
        }

        [HttpGet("{id}")]
        public IActionResult GetRetweetById(int id)
        {
            return Ok($"{id} found");
        }

        [HttpPost]
        public IActionResult CreateRetweet()
        {
            return Ok("Success");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateRetweet(int id)
        {
            return Ok($"{id} updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRetweet(int id)
        {
            return Ok($"{id} deleted");
        }
    }
}
