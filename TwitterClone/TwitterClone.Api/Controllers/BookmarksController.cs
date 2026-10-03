using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookmarksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBookmarks()
        {
            return Ok("Success");
        }

        [HttpGet("{id}")]
        public IActionResult GetBookmarkById(int id)
        {
            return Ok($"{id} found");
        }

        [HttpPost]
        public IActionResult CreateBookmark()
        {
            return Ok("Success");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateBookmark(int id)
        {
            return Ok($"{id} updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark(int id)
        {
            return Ok($"{id} deleted");
        }
    }
}
