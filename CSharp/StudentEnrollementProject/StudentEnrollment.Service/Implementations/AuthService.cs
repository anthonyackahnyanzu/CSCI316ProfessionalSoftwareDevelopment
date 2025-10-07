using StudentEnrollment.Service.Interfaces;
using StudentEnrollment.Service.Models;
using StudentEnrollment.Repository.Interfaces;
using StudentEnrollment.Repository.Entities;
using Microsoft.Extensions.Options;
using StudentEnrollment.Service.Settings;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

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

            // Ensure user has at least one approved role
            var approvedRoles = await _userRepo.GetUserRolesAsync(user.UserId, onlyApproved: true);
            if (!approvedRoles.Any())
                return null;

            var permissions = await _userRepo.GetUserPermissionsAsync(user.UserId);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };
            claims.AddRange(approvedRoles.Select(r => new Claim(ClaimTypes.Role, r)));
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
            if (result > 0)
            {
                // Assign role to user with ApprovalStatusId = 1 (Pending)
                await _userRepo.AddUserRoleAsync(user.UserId, model.RoleId, 1);
                return true;
            }
            return false;
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