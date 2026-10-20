using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos.RetweetsDto;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetweetsController : ControllerBase
    {
        private readonly IRetweetService _retweetService;

        public RetweetsController(IRetweetService retweetService)
        {
            _retweetService = retweetService;
        }

        [HttpGet]
        public IActionResult GetRetweets()
        {
            var retweets = _retweetService.GetRetweets();
            return Ok(retweets);
        }

        [HttpGet("{id}")]
        public IActionResult GetRetweetById([FromRoute] Guid id)
        {
            var retweet = _retweetService.GetRetweetById(id);

            if (retweet == null)
                return NotFound("Retweet not found");

            return Ok(retweet);
        }

        [HttpPost]
        public IActionResult CreateRetweet(
            [FromBody] CreateRetweetDto createRetweetDto)
        {
            var createdRetweet = _retweetService.AddRetweet(createRetweetDto);

            if (createdRetweet == null)
                return BadRequest("Failed to create retweet.");

            return Ok(createdRetweet);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRetweet([FromRoute] Guid id)
        {
            var isDeleted = _retweetService.DeleteRetweet(id);

            if (isDeleted != true)
                return NotFound("Retweet could not be deleted.");

            return Ok("Retweet deleted successfully.");
        }
    }
}