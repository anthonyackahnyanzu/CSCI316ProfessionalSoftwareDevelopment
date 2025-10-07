using AutoMapper;
using StudentEnrollment.Repository.Interfaces;
using StudentEnrollment.Service.Interfaces;
using StudentEnrollment.Service.Models;
using StudentEnrollment.Repository.Entities;

namespace StudentEnrollment.Service.Implementations
{
    public class CourseDepartmentService : ICourseDepartmentService
    {
        private readonly ICourseDepartmentRepository _repo;
        private readonly IMapper _mapper;
        public CourseDepartmentService(ICourseDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // Course CRUD
        public async Task<IEnumerable<CourseModel>> GetAllCoursesAsync()
        {
            var entities = await _repo.GetAllCoursesAsync();
            return _mapper.Map<IEnumerable<CourseModel>>(entities);
        }

        public async Task<CourseModel> GetCourseByIdAsync(int id)
        {
            var entity = await _repo.GetCourseByIdAsync(id);
            return _mapper.Map<CourseModel>(entity);
        }

        public async Task<int> AddCourseAsync(CourseModel course)
        {
            var entity = _mapper.Map<CourseEntity>(course);
            return await _repo.AddCourseAsync(entity);
        }

        public async Task<int> UpdateCourseAsync(CourseModel course)
        {
            var entity = _mapper.Map<CourseEntity>(course);
            return await _repo.UpdateCourseAsync(entity);
        }

        public async Task<int> DeleteCourseAsync(int id) =>
            await _repo.DeleteCourseAsync(id);

        // Department CRUD
        public async Task<IEnumerable<DepartmentModel>> GetAllDepartmentsAsync()
        {
            var entities = await _repo.GetAllDepartmentsAsync();
            return _mapper.Map<IEnumerable<DepartmentModel>>(entities);
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int id)
        {
            var entity = await _repo.GetDepartmentByIdAsync(id);
            return _mapper.Map<DepartmentModel>(entity);
        }

        public async Task<int> AddDepartmentAsync(DepartmentModel department)
        {
            var entity = _mapper.Map<DepartmentEntity>(department);
            return await _repo.AddDepartmentAsync(entity);
        }

        public async Task<int> UpdateDepartmentAsync(DepartmentModel department)
        {
            var entity = _mapper.Map<DepartmentEntity>(department);
            return await _repo.UpdateDepartmentAsync(entity);
        }

        public async Task<int> DeleteDepartmentAsync(int id) =>
            await _repo.DeleteDepartmentAsync(id);
    }
}