using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos.TweetsDto;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        public TweetsController(
            ITweetService tweetService
            )
        {
            _tweetService = tweetService;
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = _tweetService.GetTweets();

            return Ok(tweets);
        }

        [HttpGet("{id}")]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            var tweet = _tweetService.GetTweetById(id);
            if (tweet == null)
            {
                return NotFound("Tweet not found");
            }

            return Ok(tweet);
        }

        [HttpPost]
        public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto)
        {
            var createdTweet = _tweetService.AddTweet(createTweetDto);
            if (createdTweet == null)
            {
                return BadRequest("Failed to create tweet.");
            }

            return Ok(createdTweet);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] UpdateTweetDto updateTweetDto)
        {
            var updatedTweet = _tweetService.UpdateTweet(id, updateTweetDto);
            if (updatedTweet == null)
            {
                return NotFound("Tweet not found");
            }

            return Ok(updatedTweet);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var tweet = _tweetService.DeleteTweet(id);
            if (tweet == false)
                return NotFound("Tweet could not be deleted.");

            return Ok("Tweet deleted successfully.");
        }
    }
}
