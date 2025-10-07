using System.Data;
using Dapper;
using StudentEnrollment.Repository.Entities;
using StudentEnrollment.Repository.Interfaces;

namespace StudentEnrollment.Repository.Implementations
{
    public class CourseDepartmentRepository : ICourseDepartmentRepository
    {
        private readonly IDbConnection _db;
        public CourseDepartmentRepository(IDbConnection db) { _db = db; }

        // Course CRUD
        public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync() =>
            await _db.QueryAsync<CourseEntity>("SELECT * FROM Course");

        public async Task<CourseEntity> GetCourseByIdAsync(int id) =>
            await _db.QueryFirstOrDefaultAsync<CourseEntity>("SELECT * FROM Course WHERE CourseId = @id", new { id });

        public async Task<int> AddCourseAsync(CourseEntity course) =>
            await _db.ExecuteAsync("INSERT INTO Course (CourseName, DepartmentId, Credits) VALUES (@CourseName, @DepartmentId, @Credits)", course);

        public async Task<int> UpdateCourseAsync(CourseEntity course) =>
            await _db.ExecuteAsync("UPDATE Course SET CourseName = @CourseName, DepartmentId = @DepartmentId, Credits = @Credits WHERE CourseId = @CourseId", course);

        public async Task<int> DeleteCourseAsync(int id) =>
            await _db.ExecuteAsync("DELETE FROM Course WHERE CourseId = @id", new { id });

        // Department CRUD
        public async Task<IEnumerable<DepartmentEntity>> GetAllDepartmentsAsync() =>
            await _db.QueryAsync<DepartmentEntity>("SELECT * FROM Department");

        public async Task<DepartmentEntity> GetDepartmentByIdAsync(int id) =>
            await _db.QueryFirstOrDefaultAsync<DepartmentEntity>("SELECT * FROM Department WHERE DepartmentId = @id", new { id });

        public async Task<int> AddDepartmentAsync(DepartmentEntity department) =>
            await _db.ExecuteAsync("INSERT INTO Department (DepartmentName) VALUES (@DepartmentName)", department);

        public async Task<int> UpdateDepartmentAsync(DepartmentEntity department) =>
            await _db.ExecuteAsync("UPDATE Department SET DepartmentName = @DepartmentName WHERE DepartmentId = @DepartmentId", department);

        public async Task<int> DeleteDepartmentAsync(int id) =>
            await _db.ExecuteAsync("DELETE FROM Department WHERE DepartmentId = @id", new { id });
    }
}