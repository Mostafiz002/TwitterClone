using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public IActionResult LikeTweet(CreateLikeDto dto)
        {
            try
            {
                var like = _likeService.LikeTweet(dto);

                return CreatedAtAction(
                    nameof(GetLikeById),
                    new { id = like.Id },
                    like);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet("tweet/{tweetId:guid}")]
        public IActionResult GetLikesByTweetId(Guid tweetId)
        {
            return Ok(_likeService.GetLikesByTweetId(tweetId));
        }

        [HttpGet("user/{userId:guid}")]
        public IActionResult GetLikesByUserId(Guid userId)
        {
            return Ok(_likeService.GetLikesByUserId(userId));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetLikeById(Guid id)
        {
            var like = _likeService.GetLikeById(id);

            return like is null ? NotFound() : Ok(like);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult UnlikeTweet(Guid id)
        {
            return _likeService.UnlikeTweet(id)
                ? NoContent()
                : NotFound();
        }
    }
}