using StudentEnrollment.Service.Models;

namespace StudentEnrollment.Service.Interfaces
{
    public interface ICourseDepartmentService
    {
        // Course CRUD
        Task<IEnumerable<CourseModel>> GetAllCoursesAsync();
        Task<CourseModel> GetCourseByIdAsync(int id);
        Task<int> AddCourseAsync(CourseModel course);
        Task<int> UpdateCourseAsync(CourseModel course);
        Task<int> DeleteCourseAsync(int id);

        // Department CRUD
        Task<IEnumerable<DepartmentModel>> GetAllDepartmentsAsync();
        Task<DepartmentModel> GetDepartmentByIdAsync(int id);
        Task<int> AddDepartmentAsync(DepartmentModel department);
        Task<int> UpdateDepartmentAsync(DepartmentModel department);
        Task<int> DeleteDepartmentAsync(int id);
    }
}