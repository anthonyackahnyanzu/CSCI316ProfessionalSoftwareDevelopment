using StudentEnrollment.Repository.Entities;

namespace StudentEnrollment.Repository.Interfaces
{
    public interface IEnrollmentOfferingSemesterRepository
    {
        // Enrollment CRUD
        Task<IEnumerable<EnrollmentEntity>> GetAllEnrollmentsAsync();
        Task<EnrollmentEntity> GetEnrollmentByIdAsync(int id);
        Task<int> AddEnrollmentAsync(EnrollmentEntity enrollment);
        Task<int> UpdateEnrollmentAsync(EnrollmentEntity enrollment);
        Task<int> DeleteEnrollmentAsync(int id);

        // ClassOffering CRUD
        Task<IEnumerable<ClassOfferingEntity>> GetAllClassOfferingsAsync();
        Task<ClassOfferingEntity> GetClassOfferingByIdAsync(int id);
        Task<int> AddClassOfferingAsync(ClassOfferingEntity offering);
        Task<int> UpdateClassOfferingAsync(ClassOfferingEntity offering);
        Task<int> DeleteClassOfferingAsync(int id);

        // Semester CRUD
        Task<IEnumerable<SemesterEntity>> GetAllSemestersAsync();
        Task<SemesterEntity> GetSemesterByIdAsync(int id);
        Task<int> AddSemesterAsync(SemesterEntity semester);
        Task<int> UpdateSemesterAsync(SemesterEntity semester);
        Task<int> DeleteSemesterAsync(int id);
    }
}