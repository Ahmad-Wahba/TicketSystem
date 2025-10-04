using Microsoft.AspNetCore.Mvc;
using TicketSystem.Core.DTOs;
using TicketSystem.Core.Interfaces;

namespace TicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IITTeamService _teamService;

        public AccountController(IUserService userService, ITokenService tokenService, IITTeamService iTTeamService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _teamService = iTTeamService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<object>> Login(LoginDto loginDto)
        {
            if (loginDto.Role == "Employee")
            {
                var user = await _userService.GetUserByEmailAsync(loginDto.Email);
                if (user == null) return Unauthorized("Invalid email or password");

                var result = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
                if (!result) return Unauthorized("Invalid email or password");

                return new { token = _tokenService.CreateToken(user) };
            }
            else if (loginDto.Role == "IT")
            {
                var itMember = await _teamService.GetByEmailAsync(loginDto.Email);
                if (itMember == null) return Unauthorized("Invalid email or password");

                var result = BCrypt.Net.BCrypt.Verify(loginDto.Password, itMember.PasswordHash);
                if (!result) return Unauthorized("Invalid email or password");

                return new { token = _tokenService.CreateToken(itMember) };
            }

            return Unauthorized("Invalid role");
        }
    
    }
}
