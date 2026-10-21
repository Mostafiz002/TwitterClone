using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowsController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowsController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost]
        public IActionResult FollowUser(CreateFollowDto dto)
        {
            try
            {
                var follow = _followService.FollowUser(dto);

                return CreatedAtAction(
                    nameof(GetFollowById),
                    new { id = follow.Id },
                    follow);
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

        [HttpGet("{id:guid}")]
        public IActionResult GetFollowById(Guid id)
        {
            var follow = _followService.GetFollowById(id);

            return follow is null ? NotFound() : Ok(follow);
        }

        [HttpGet("followers/{userId:guid}")]
        public IActionResult GetFollowers(Guid userId)
        {
            return Ok(_followService.GetFollowers(userId));
        }

        [HttpGet("following/{userId:guid}")]
        public IActionResult GetFollowing(Guid userId)
        {
            return Ok(_followService.GetFollowing(userId));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult UnfollowUser(Guid id)
        {
            return _followService.UnfollowUser(id)
                ? NoContent()
                : NotFound();
        }
    }
}