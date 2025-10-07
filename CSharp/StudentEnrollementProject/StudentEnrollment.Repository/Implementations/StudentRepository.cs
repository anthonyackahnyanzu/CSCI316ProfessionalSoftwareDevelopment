using Dapper;
using StudentEnrollment.Repository.Entities;
using StudentEnrollment.Repository.Interfaces;
using StudentEnrollment.Repository.Sql;
using System.Data;

namespace StudentEnrollment.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbConnection _db;
        public StudentRepository(IDbConnection db) { _db = db; }

        public async Task<IEnumerable<StudentEntity>> GetAllAsync() =>
            await _db.QueryAsync<StudentEntity>(SutudentSql.GetAllStudents);

        public async Task<StudentEntity> GetByIdAsync(int id) =>
            await _db.QueryFirstOrDefaultAsync<StudentEntity>("SELECT * FROM Student WHERE StudentId = @id", new { id });

        public async Task<int> AddAsync(StudentEntity student) =>
            await _db.ExecuteAsync("INSERT INTO Student (FirstName, LastName, Email, DepartmentId) VALUES (@FirstName, @LastName, @Email, @DepartmentId)", student);

        public async Task<int> UpdateAsync(StudentEntity student) =>
            await _db.ExecuteAsync("UPDATE Student SET FirstName = @FirstName, LastName = @LastName, Email = @Email, DepartmentId = @DepartmentId WHERE StudentId = @StudentId", student);

        public async Task<int> DeleteAsync(int id) =>
            await _db.ExecuteAsync("DELETE FROM Student WHERE StudentId = @id", new { id });
    }
}