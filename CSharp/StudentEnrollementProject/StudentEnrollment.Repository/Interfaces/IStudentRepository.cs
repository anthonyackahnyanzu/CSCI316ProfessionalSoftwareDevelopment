using StudentEnrollment.Repository.Entities;

namespace StudentEnrollment.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentEntity>> GetAllAsync();
        Task<StudentEntity> GetByIdAsync(int id);
        Task<int> AddAsync(StudentEntity student);
        Task<int> UpdateAsync(StudentEntity student);
        Task<int> DeleteAsync(int id);
    }
}