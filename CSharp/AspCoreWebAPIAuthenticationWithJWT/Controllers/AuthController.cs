using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspCoreWebAPIAuthenticationWithJWT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // In-memory user store for demo purposes
        private static List<User> Users = new List<User>
        {
            new User { Username = "alice", Password = "password1", CanRead = true, CanEdit = false, FullAccess = false },
            new User { Username = "bob", Password = "password2", CanRead = true, CanEdit = true, FullAccess = false },
            new User { Username = "admin", Password = "adminpass", CanRead = true, CanEdit = true, FullAccess = true }
        };

        // POST: api/auth/signup
        // Adds a new user to the in-memory list
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] SignUpRequest request)
        {
            if (Users.Any(u => u.Username == request.Username))
                return BadRequest("Username already exists.");
            Users.Add(new User
            {
                Username = request.Username,
                Password = request.Password,
                CanRead = request.CanRead,
                CanEdit = request.CanEdit,
                FullAccess = request.FullAccess
            });
            return Ok("User registered successfully.");
        }

        // POST: api/auth/login
        // Validates user and issues JWT with claims
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            if (user == null)
                return Unauthorized("Invalid username or password.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("CanRead", user.CanRead.ToString().ToLower()),
                new Claim("CanEdit", user.CanEdit.ToString().ToLower()),
                new Claim("FullAccess", user.FullAccess.ToString().ToLower())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKeyForJwtToken123!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "AspCoreWebAPIAuthenticationWithJWT",
                audience: "AspCoreWebAPIAuthenticationWithJWTUsers",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        // GET: api/auth/users
        // Returns the list of users and their claims
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Ok(Users.Select(u => new
            {
                u.Username,
                u.CanRead,
                u.CanEdit,
                u.FullAccess
            }));
        }
    }

    // DTO for login request
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // DTO for signup request
    public class SignUpRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool CanRead { get; set; }
        public bool CanEdit { get; set; }
        public bool FullAccess { get; set; }
    }

    // In-memory user model
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool CanRead { get; set; }
        public bool CanEdit { get; set; }
        public bool FullAccess { get; set; }
    }
}
