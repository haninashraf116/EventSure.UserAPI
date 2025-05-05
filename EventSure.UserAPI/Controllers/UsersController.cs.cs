using Microsoft.AspNetCore.Mvc;
using EventSure.UserAPI.Models;
using EventSure.UserAPI.Services;

namespace EventSure.UserAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService = new();

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var user = new UserAccount
            {
                Username = request.Username,
                Email = request.Email,
                MembershipTier = request.MembershipTier
            };

            var success = _userService.Register(user, request.Password);
            if (!success)
                return BadRequest(new { message = "Email already exists." });

            return Ok(new { message = "Registration successful." });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var success = _userService.Login(request.Email, request.Password);
            if (!success)
                return Unauthorized(new { message = "Invalid credentials." });

            return Ok(new { message = "Login successful." });
        }
    }

    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MembershipTier { get; set; } = "General";
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

