using Microsoft.AspNetCore.Mvc;
using StudentEnrollmentService;
using System.Threading.Tasks;

namespace StudentEnrollmentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;
        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // Additional routes for registration, class offerings, etc. can be added here
    }
}
