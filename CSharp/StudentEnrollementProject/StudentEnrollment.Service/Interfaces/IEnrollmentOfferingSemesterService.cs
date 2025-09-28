using System.Collections.Generic;
using System.Threading.Tasks;
using StudentEnrollment.Service.Models;

namespace StudentEnrollment.Service.Interfaces
{
    public interface IEnrollmentOfferingSemesterService
    {
        // Enrollment CRUD
        Task<IEnumerable<EnrollmentModel>> GetAllEnrollmentsAsync();
        Task<EnrollmentModel> GetEnrollmentByIdAsync(int id);
        Task<int> AddEnrollmentAsync(EnrollmentModel enrollment);
        Task<int> UpdateEnrollmentAsync(EnrollmentModel enrollment);
        Task<int> DeleteEnrollmentAsync(int id);

        // ClassOffering CRUD
        Task<IEnumerable<ClassOfferingModel>> GetAllClassOfferingsAsync();
        Task<ClassOfferingModel> GetClassOfferingByIdAsync(int id);
        Task<int> AddClassOfferingAsync(ClassOfferingModel offering);
        Task<int> UpdateClassOfferingAsync(ClassOfferingModel offering);
        Task<int> DeleteClassOfferingAsync(int id);

        // Semester CRUD
        Task<IEnumerable<SemesterModel>> GetAllSemestersAsync();
        Task<SemesterModel> GetSemesterByIdAsync(int id);
        Task<int> AddSemesterAsync(SemesterModel semester);
        Task<int> UpdateSemesterAsync(SemesterModel semester);
        Task<int> DeleteSemesterAsync(int id);
    }
}