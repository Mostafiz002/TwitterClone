using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TweetsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void GetTweet()
        {
            var connectionString = _configuration.GetValue<string>("Logging:LogLevel:Default");
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            var maxTweetLength = _configuration.GetValue<int>("TwitterSettings:MaxTweetLength");

            var tweets = new List<Tweet>
            {
                new Tweet("1: Hello world!", Guid.NewGuid()),
                new Tweet("2: Hello world", Guid.NewGuid()),
                new Tweet("3: Hello world", Guid.NewGuid())
            };

            return Ok( new
            {
                tweets = tweets,
                maxLength = maxTweetLength
            });
        }
    }
}
