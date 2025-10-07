using StudentEnrollment.Service.Interfaces;
using StudentEnrollment.Service.Models;
using StudentEnrollment.Repository.Interfaces;
using StudentEnrollment.Repository.Entities;
using Microsoft.Extensions.Options;
using StudentEnrollment.Api.Settings;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Claims;

namespace StudentEnrollment.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IUserRepository userRepo, IOptions<JwtSettings> jwtOptions)
        {
            _userRepo = userRepo;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepo.GetByUsernameAsync(username);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            var roles = await _userRepo.GetUserRolesAsync(user.UserId);
            var permissions = await _userRepo.GetUserPermissionsAsync(user.UserId);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            claims.AddRange(permissions.Select(p => new Claim("permission", p)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> RegisterAsync(UserRegisterModel model)
        {
            var user = new UserEntity
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = HashPassword(model.Password)
            };
            var result = await _userRepo.AddAsync(user);
            // Assign role to user
            // You would also insert into UserRole table here (not shown for brevity)
            return result > 0;
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}