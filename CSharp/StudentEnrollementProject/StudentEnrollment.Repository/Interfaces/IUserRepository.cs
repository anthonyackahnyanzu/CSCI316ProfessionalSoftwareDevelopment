using System.Threading.Tasks;
using StudentEnrollment.Repository.Entities;
using System.Collections.Generic;

namespace StudentEnrollment.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByUsernameAsync(string username);
        Task<UserEntity> GetByIdAsync(int userId);
        Task<int> AddAsync(UserEntity user);
        Task<IEnumerable<string>> GetUserRolesAsync(int userId, bool onlyApproved = false);
        Task<IEnumerable<string>> GetUserPermissionsAsync(int userId);
        Task AddUserRoleAsync(int userId, int roleId, int approvalStatusId);
    }
}