using AIMachineAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AIMachineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> users = new List<User>
            {
                new User { Id = 1, Username = "test", Password = "test"}
            };

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(users);
        }

        [HttpGet("self")]
        public async Task<IActionResult> GetSelf()
        {
            return Ok("self");
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            return Ok("login");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok("logout");
        }
        [HttpPost("create")]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            users.Add(user);
            return Ok(user);
        }
    }
}
