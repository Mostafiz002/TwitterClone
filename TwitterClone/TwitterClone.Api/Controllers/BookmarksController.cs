using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookmarksController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;

        public BookmarksController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }

        [HttpPost]
        public IActionResult CreateBookmark(CreateBookmarkDto dto)
        {
            try
            {
                var bookmark = _bookmarkService.CreateBookmark(dto);

                return CreatedAtAction(
                    nameof(GetBookmarkById),
                    new { id = bookmark.Id },
                    bookmark);
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
        public IActionResult GetBookmarkById(Guid id)
        {
            var bookmark = _bookmarkService.GetBookmarkById(id);

            return bookmark is null ? NotFound() : Ok(bookmark);
        }

        [HttpGet("user/{userId:guid}")]
        public IActionResult GetBookmarksByUserId(Guid userId)
        {
            try
            {
                return Ok(_bookmarkService.GetBookmarksByUserId(userId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult RemoveBookmark(Guid id)
        {
            return _bookmarkService.RemoveBookmark(id)
                ? NoContent()
                : NotFound();
        }
    }
}