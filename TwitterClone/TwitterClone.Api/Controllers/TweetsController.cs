using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.Dtos.TweetsDto;
using TwitterClone.Api.Dtos.UsersDto;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly TweetRepository _tweetRepository;

        public TweetsController(
            TweetRepository tweetRepository
            )
        {
            _tweetRepository = tweetRepository;
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = _tweetRepository.GetTweets();

            return Ok(tweets.Select(tweet => new TweetDto
            {
                Id = tweet.Id.ToString(),
                Content = tweet.Content,
                UserId = tweet.UserId.ToString()
            }));
        }

        [HttpGet("{id}")]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            return Ok(new TweetDto
            {
                Id = tweet.Id.ToString(),
                Content = tweet.Content,
                UserId = tweet.UserId.ToString()
            });
        }

        [HttpPost]
        public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto)
        {
            if (string.IsNullOrWhiteSpace(createTweetDto.Content) ||
                createTweetDto.UserId == Guid.Empty
                )
            {
                return BadRequest("All fields are required.");
            }

            var createTweet = _tweetRepository.AddTweet(new Tweet(createTweetDto.Content,
                createTweetDto.UserId)
            { });

            return Ok(new TweetDto
            {
                Id = createTweet.Id.ToString(),
                Content = createTweet.Content,
                UserId = createTweet.UserId.ToString()
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] UpdateTweetDto updateTweetDto)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if(tweet == null)
                return NotFound("Tweet not found");

            tweet.UpdateContent(updateTweetDto.Content);

            var updatedTweet = _tweetRepository.UpdateTweet(tweet);

            return Ok(new TweetDto
            {
                Id = updatedTweet.Id.ToString(),
                Content = updatedTweet.Content,
                UserId = updatedTweet.UserId.ToString()
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if (tweet == null)
                return NotFound("Tweet not found");

            var isDeleted = _tweetRepository.DeleteTweet(tweet);
            if (!isDeleted)
                return StatusCode(500, "Failed to delete tweet");

            return Ok(new TweetDto
            {
                Id = tweet.Id.ToString(),
                Content = tweet.Content,
                UserId = tweet.UserId.ToString()
            });
        }
    }
}
