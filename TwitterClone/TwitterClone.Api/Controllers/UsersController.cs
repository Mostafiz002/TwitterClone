using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
