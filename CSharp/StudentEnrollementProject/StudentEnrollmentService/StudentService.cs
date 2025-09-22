using AutoMapper;
using StudentEnrollentReposiotry.Entities;
using StudentEnrollentReposiotry.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentEnrollmentService
{
    // Example service combining repository and AutoMapper
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
    }

    // Example model for service layer
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    }
}
