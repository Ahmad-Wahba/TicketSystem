using Microsoft.AspNetCore.Mvc;
using TicketSystem.Core.Interfaces;
using TicketSystem.Core.DTOs;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userDto)
        {
            var user = await _userService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user); ;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewDto>>> GetAllUsers()
        {
           var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUser(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
