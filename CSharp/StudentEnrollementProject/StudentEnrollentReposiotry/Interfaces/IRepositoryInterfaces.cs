using System.Collections.Generic;
using System.Threading.Tasks;
using StudentEnrollentReposiotry.Entities;

namespace StudentEnrollentReposiotry.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentEntity>> GetAllAsync();
        Task<StudentEntity> GetByIdAsync(int id);
        Task<int> AddAsync(StudentEntity student);
        Task<int> UpdateAsync(StudentEntity student);
        Task<int> DeleteAsync(int id);
    }

    public interface ICourseRepository
    {
        Task<IEnumerable<CourseEntity>> GetAllAsync();
        Task<CourseEntity> GetByIdAsync(int id);
        Task<int> AddAsync(CourseEntity course);
        Task<int> UpdateAsync(CourseEntity course);
        Task<int> DeleteAsync(int id);
    }

    public interface IDepartmentRepository
    {
        Task<IEnumerable<DepartmentEntity>> GetAllAsync();
        Task<DepartmentEntity> GetByIdAsync(int id);
        Task<int> AddAsync(DepartmentEntity department);
        Task<int> UpdateAsync(DepartmentEntity department);
        Task<int> DeleteAsync(int id);
    }

    public interface IClassroomRepository
    {
        Task<IEnumerable<ClassroomEntity>> GetAllAsync();
        Task<ClassroomEntity> GetByIdAsync(int id);
        Task<int> AddAsync(ClassroomEntity classroom);
        Task<int> UpdateAsync(ClassroomEntity classroom);
        Task<int> DeleteAsync(int id);
    }

    public interface IProfessorRepository
    {
        Task<IEnumerable<ProfessorEntity>> GetAllAsync();
        Task<ProfessorEntity> GetByIdAsync(int id);
        Task<int> AddAsync(ProfessorEntity professor);
        Task<int> UpdateAsync(ProfessorEntity professor);
        Task<int> DeleteAsync(int id);
    }

    public interface ISemesterRepository
    {
        Task<IEnumerable<SemesterEntity>> GetAllAsync();
        Task<SemesterEntity> GetByIdAsync(int id);
        Task<int> AddAsync(SemesterEntity semester);
        Task<int> UpdateAsync(SemesterEntity semester);
        Task<int> DeleteAsync(int id);
    }

    public interface IClassOfferingRepository
    {
        Task<IEnumerable<ClassOfferingEntity>> GetAllAsync();
        Task<ClassOfferingEntity> GetByIdAsync(int id);
        Task<int> AddAsync(ClassOfferingEntity offering);
        Task<int> UpdateAsync(ClassOfferingEntity offering);
        Task<int> DeleteAsync(int id);
    }

    public interface IEnrollmentRepository
    {
        Task<IEnumerable<EnrollmentEntity>> GetAllAsync();
        Task<EnrollmentEntity> GetByIdAsync(int id);
        Task<int> AddAsync(EnrollmentEntity enrollment);
        Task<int> UpdateAsync(EnrollmentEntity enrollment);
        Task<int> DeleteAsync(int id);
    }
}
