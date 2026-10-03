using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppNameController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AppNameController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet()]
        public IActionResult GetConfig()
        {
            var appName = _configuration["AppName"];

            return Ok(new
            {
                appName
            });
        }
    }
}
