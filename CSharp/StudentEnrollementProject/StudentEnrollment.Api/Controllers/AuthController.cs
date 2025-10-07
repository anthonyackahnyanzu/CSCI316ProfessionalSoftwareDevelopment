using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Service.Interfaces;
using StudentEnrollment.Service.Models;
using System.Threading.Tasks;

namespace StudentEnrollment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _authService.AuthenticateAsync(model.Username, model.Password);
            if (token == null) return Unauthorized("Invalid username or password, or your role is not approved.");
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var success = await _authService.RegisterAsync(model);
            if (!success) return BadRequest("Registration failed. Username might already be taken.");
            return Ok("Registration successful. Please wait for admin approval to activate your role.");
        }
    }
}
