using EmailPlanner_Alpha.Server.Services.UserService;
using EmailPlanner_Alpha.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailPlanner_Alpha.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            var result = await _userService.UpdateUser(user);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            var result = await _userService.UpdateUser(user);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }
    }
}
