using System.Threading.Tasks;
using StudentEnrollment.Service.Models;

namespace StudentEnrollment.Service.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task<bool> RegisterAsync(UserRegisterModel model);
    }
}