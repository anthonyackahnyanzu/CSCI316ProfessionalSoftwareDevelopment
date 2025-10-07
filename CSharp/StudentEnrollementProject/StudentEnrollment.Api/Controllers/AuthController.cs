using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentEnrollment.Api.Settings;
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
        private readonly JwtSettings _jwtSettings;
        public AuthController(IAuthService authService, IOptions<JwtSettings> jwtOptions)
        {
            _authService = authService;
            _jwtSettings = jwtOptions.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _authService.AuthenticateAsync(model.Username, model.Password);
            if (token == null) return Unauthorized();
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            var success = await _authService.RegisterAsync(model);
            if (!success) return BadRequest("Registration failed.");
            return Ok("User registered.");
        }
    }
}
