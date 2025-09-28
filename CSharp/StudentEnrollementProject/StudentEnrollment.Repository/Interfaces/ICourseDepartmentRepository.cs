using System.Collections.Generic;
using System.Threading.Tasks;
using StudentEnrollment.Repository.Entities;

namespace StudentEnrollment.Repository.Interfaces
{
    public interface ICourseDepartmentRepository
    {
        // Course CRUD
        Task<IEnumerable<CourseEntity>> GetAllCoursesAsync();
        Task<CourseEntity> GetCourseByIdAsync(int id);
        Task<int> AddCourseAsync(CourseEntity course);
        Task<int> UpdateCourseAsync(CourseEntity course);
        Task<int> DeleteCourseAsync(int id);

        // Department CRUD
        Task<IEnumerable<DepartmentEntity>> GetAllDepartmentsAsync();
        Task<DepartmentEntity> GetDepartmentByIdAsync(int id);
        Task<int> AddDepartmentAsync(DepartmentEntity department);
        Task<int> UpdateDepartmentAsync(DepartmentEntity department);
        Task<int> DeleteDepartmentAsync(int id);
    }
}