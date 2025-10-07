using AutoMapper;
using StudentEnrollment.Repository.Interfaces;
using StudentEnrollment.Service.Interfaces;
using StudentEnrollment.Service.Models;
using StudentEnrollment.Repository.Entities;

namespace StudentEnrollment.Service.Implementations
{
    public class EnrollmentOfferingSemesterService : IEnrollmentOfferingSemesterService
    {
        private readonly IEnrollmentOfferingSemesterRepository _repo;
        private readonly IMapper _mapper;
        public EnrollmentOfferingSemesterService(IEnrollmentOfferingSemesterRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Enrollment CRUD
        public async Task<IEnumerable<EnrollmentModel>> GetAllEnrollmentsAsync()
        {
            var entities = await _repo.GetAllEnrollmentsAsync();
            return _mapper.Map<IEnumerable<EnrollmentModel>>(entities);
        }

        public async Task<EnrollmentModel> GetEnrollmentByIdAsync(int id)
        {
            var entity = await _repo.GetEnrollmentByIdAsync(id);
            return _mapper.Map<EnrollmentModel>(entity);
        }

        public async Task<int> AddEnrollmentAsync(EnrollmentModel enrollment)
        {
            var entity = _mapper.Map<EnrollmentEntity>(enrollment);
            return await _repo.AddEnrollmentAsync(entity);
        }

        public async Task<int> UpdateEnrollmentAsync(EnrollmentModel enrollment)
        {
            var entity = _mapper.Map<EnrollmentEntity>(enrollment);
            return await _repo.UpdateEnrollmentAsync(entity);
        }

        public async Task<int> DeleteEnrollmentAsync(int id) =>
            await _repo.DeleteEnrollmentAsync(id);

        // ClassOffering CRUD
        public async Task<IEnumerable<ClassOfferingModel>> GetAllClassOfferingsAsync()
        {
            var entities = await _repo.GetAllClassOfferingsAsync();
            return _mapper.Map<IEnumerable<ClassOfferingModel>>(entities);
        }

        public async Task<ClassOfferingModel> GetClassOfferingByIdAsync(int id)
        {
            var entity = await _repo.GetClassOfferingByIdAsync(id);
            return _mapper.Map<ClassOfferingModel>(entity);
        }

        public async Task<int> AddClassOfferingAsync(ClassOfferingModel offering)
        {
            var entity = _mapper.Map<ClassOfferingEntity>(offering);
            return await _repo.AddClassOfferingAsync(entity);
        }

        public async Task<int> UpdateClassOfferingAsync(ClassOfferingModel offering)
        {
            var entity = _mapper.Map<ClassOfferingEntity>(offering);
            return await _repo.UpdateClassOfferingAsync(entity);
        }

        public async Task<int> DeleteClassOfferingAsync(int id) =>
            await _repo.DeleteClassOfferingAsync(id);

        // Semester CRUD
        public async Task<IEnumerable<SemesterModel>> GetAllSemestersAsync()
        {
            var entities = await _repo.GetAllSemestersAsync();
            return _mapper.Map<IEnumerable<SemesterModel>>(entities);
        }

        public async Task<SemesterModel> GetSemesterByIdAsync(int id)
        {
            var entity = await _repo.GetSemesterByIdAsync(id);
            return _mapper.Map<SemesterModel>(entity);
        }

        public async Task<int> AddSemesterAsync(SemesterModel semester)
        {
            var entity = _mapper.Map<SemesterEntity>(semester);
            return await _repo.AddSemesterAsync(entity);
        }

        public async Task<int> UpdateSemesterAsync(SemesterModel semester)
        {
            var entity = _mapper.Map<SemesterEntity>(semester);
            return await _repo.UpdateSemesterAsync(entity);
        }

        public async Task<int> DeleteSemesterAsync(int id) =>
            await _repo.DeleteSemesterAsync(id);
    }
}