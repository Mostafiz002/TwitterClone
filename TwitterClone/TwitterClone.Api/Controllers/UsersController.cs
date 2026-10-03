using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<User>
            {
                new User("mo@gmail.com")
                {
                    FirstName = "Mahi",
                    LastName = "Sori"
                },
                new User("po@gmail.com"),
                new User("so@gmail.com")
            };

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            return Ok(new User("mo@gmail.com")
            {
                FirstName = "Mahi",
                LastName = "Sori"
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser()
        {
            return Ok(new
            {
                UserId = Guid.NewGuid(),
                UserName = "NewUser",
            });
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateUser(int id)
        {
            return Ok($"{id} updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok($"{id} deleted");
        }
    }
}
