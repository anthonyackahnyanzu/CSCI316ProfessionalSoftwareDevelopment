using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using StudentEnrollment.Repository.Entities;
using StudentEnrollment.Repository.Interfaces;

namespace StudentEnrollment.Repository.Implementations
{
    public class EnrollmentOfferingSemesterRepository : IEnrollmentOfferingSemesterRepository
    {
        private readonly IDbConnection _db;
        public EnrollmentOfferingSemesterRepository(IDbConnection db) { _db = db; }

        // Enrollment CRUD
        public async Task<IEnumerable<EnrollmentEntity>> GetAllEnrollmentsAsync() =>
            await _db.QueryAsync<EnrollmentEntity>("SELECT * FROM Enrollment");

        public async Task<EnrollmentEntity> GetEnrollmentByIdAsync(int id) =>
            await _db.QueryFirstOrDefaultAsync<EnrollmentEntity>("SELECT * FROM Enrollment WHERE EnrollmentId = @id", new { id });

        public async Task<int> AddEnrollmentAsync(EnrollmentEntity enrollment) =>
            await _db.ExecuteAsync("INSERT INTO Enrollment (StudentId, ClassOfferingId, EnrollmentDate) VALUES (@StudentId, @ClassOfferingId, @EnrollmentDate)", enrollment);

        public async Task<int> UpdateEnrollmentAsync(EnrollmentEntity enrollment) =>
            await _db.ExecuteAsync("UPDATE Enrollment SET StudentId = @StudentId, ClassOfferingId = @ClassOfferingId, EnrollmentDate = @EnrollmentDate WHERE EnrollmentId = @EnrollmentId", enrollment);

        public async Task<int> DeleteEnrollmentAsync(int id) =>
            await _db.ExecuteAsync("DELETE FROM Enrollment WHERE EnrollmentId = @id", new { id });

        // ClassOffering CRUD
        public async Task<IEnumerable<ClassOfferingEntity>> GetAllClassOfferingsAsync() =>
            await _db.QueryAsync<ClassOfferingEntity>("SELECT * FROM ClassOffering");

        public async Task<ClassOfferingEntity> GetClassOfferingByIdAsync(int id) =>
            await _db.QueryFirstOrDefaultAsync<ClassOfferingEntity>("SELECT * FROM ClassOffering WHERE ClassOfferingId = @id", new { id });

        public async Task<int> AddClassOfferingAsync(ClassOfferingEntity offering) =>
            await _db.ExecuteAsync("INSERT INTO ClassOffering (CourseId, ProfessorId, ClassroomId, SemesterId, Schedule) VALUES (@CourseId, @ProfessorId, @ClassroomId, @SemesterId, @Schedule)", offering);

        public async Task<int> UpdateClassOfferingAsync(ClassOfferingEntity offering) =>
            await _db.ExecuteAsync("UPDATE ClassOffering SET CourseId = @CourseId, ProfessorId = @ProfessorId, ClassroomId = @ClassroomId, SemesterId = @SemesterId, Schedule = @Schedule WHERE ClassOfferingId = @ClassOfferingId", offering);

        public async Task<int> DeleteClassOfferingAsync(int id) =>
            await _db.ExecuteAsync("DELETE FROM ClassOffering WHERE ClassOfferingId = @id", new { id });

        // Semester CRUD
        public async Task<IEnumerable<SemesterEntity>> GetAllSemestersAsync() =>
            await _db.QueryAsync<SemesterEntity>("SELECT * FROM Semester");

        public async Task<SemesterEntity> GetSemesterByIdAsync(int id) =>
            await _db.QueryFirstOrDefaultAsync<SemesterEntity>("SELECT * FROM Semester WHERE SemesterId = @id", new { id });

        public async Task<int> AddSemesterAsync(SemesterEntity semester) =>
            await _db.ExecuteAsync("INSERT INTO Semester (Name, StartDate, EndDate) VALUES (@Name, @StartDate, @EndDate)", semester);

        public async Task<int> UpdateSemesterAsync(SemesterEntity semester) =>
            await _db.ExecuteAsync("UPDATE Semester SET Name = @Name, StartDate = @StartDate, EndDate = @EndDate WHERE SemesterId = @SemesterId", semester);

        public async Task<int> DeleteSemesterAsync(int id) =>
            await _db.ExecuteAsync("DELETE FROM Semester WHERE SemesterId = @id", new { id });
    }
}