using AIMachineAPI.Authorization;
using AIMachineAPI.Models;
using AIMachineAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AIMachineAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("self")]
        public async Task<IActionResult> GetSelf()
        {
            return await Task.Run(() => Ok("self"));
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            
            return await Task.Run(() => Ok("hello"));
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            return await Task.Run(() => Ok("logout"));
        }


        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            await _userService.Add(user);
            var users = await _userService.GetAll();
            return Ok(users);
        }
    }
}
