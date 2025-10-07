using AutoMapper;
using StudentEnrollment.Repository.Interfaces;
using StudentEnrollment.Service.Models;

namespace StudentEnrollment.Service.Services
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentModel>> GetAllStudentsAsync()
        {
            var entities = await _studentRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentModel>>(entities);
        }

        public async Task<StudentModel> GetStudentByIdAsync(int id)
        {
            var entity = await _studentRepo.GetByIdAsync(id);
            return _mapper.Map<StudentModel>(entity);
        }
    }
}