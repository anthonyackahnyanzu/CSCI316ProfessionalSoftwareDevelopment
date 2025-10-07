using System.Data;
using Dapper;
using StudentEnrollment.Repository.Entities;
using StudentEnrollment.Repository.Interfaces;

namespace StudentEnrollment.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _db;
        public UserRepository(IDbConnection db) { _db = db; }

        public async Task<UserEntity> GetByUsernameAsync(string username) =>
            await _db.QueryFirstOrDefaultAsync<UserEntity>("SELECT * FROM [User] WHERE Username = @username", new { username });

        public async Task<UserEntity> GetByIdAsync(int userId) =>
            await _db.QueryFirstOrDefaultAsync<UserEntity>("SELECT * FROM [User] WHERE UserId = @userId", new { userId });

        public async Task<int> AddAsync(UserEntity user) =>
            await _db.ExecuteAsync("INSERT INTO [User] (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)", user);

        public async Task<IEnumerable<string>> GetUserRolesAsync(int userId, bool onlyApproved = false)
        {
            var sql = @"SELECT r.RoleName FROM [Role] r
                        JOIN [UserRole] ur ON ur.RoleId = r.RoleId
                        WHERE ur.UserId = @userId";
            if (onlyApproved)
                sql += " AND ur.ApprovalStatusId = 2"; // 2 = Approved
            return await _db.QueryAsync<string>(sql, new { userId });
        }

        public async Task<IEnumerable<string>> GetUserPermissionsAsync(int userId) =>
            await _db.QueryAsync<string>(
                @"SELECT p.PermissionName FROM [Permission] p
                  JOIN [RolePermission] rp ON rp.PermissionId = p.PermissionId
                  JOIN [UserRole] ur ON ur.RoleId = rp.RoleId
                  WHERE ur.UserId = @userId AND ur.ApprovalStatusId = 2
                  UNION
                  SELECT p.PermissionName FROM [Permission] p
                  JOIN [UserPermission] up ON up.PermissionId = p.PermissionId
                  WHERE up.UserId = @userId", new { userId });

        public async Task AddUserRoleAsync(int userId, int roleId, int approvalStatusId) =>
            await _db.ExecuteAsync("INSERT INTO [UserRole] (UserId, RoleId, ApprovalStatusId) VALUES (@userId, @roleId, @approvalStatusId)", new { userId, roleId, approvalStatusId });
    }
}