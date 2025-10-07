using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Service.Interfaces;
using StudentEnrollment.Service.Models;
using System.Threading.Tasks;

namespace StudentEnrollment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseDepartmentController : ControllerBase
    {
        private readonly ICourseDepartmentService _service;
        public CourseDepartmentController(ICourseDepartmentService service)
        {
            _service = service;
        }

        // Course CRUD
        [HttpGet("courses")]
        [Authorize]
        public async Task<IActionResult> GetAllCourses() =>
            Ok(await _service.GetAllCoursesAsync());

        [HttpGet("courses/{id}")]
        [Authorize]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _service.GetCourseByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost("courses")]
        [Authorize(Policy = "CanEditCourses")]
        public async Task<IActionResult> AddCourse([FromBody] CourseModel course)
        {
            var result = await _service.AddCourseAsync(course);
            return Ok(result);
        }

        [HttpPut("courses/{id}")]
        [Authorize(Policy = "CanEditCourses")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseModel course)
        {
            course.CourseId = id;
            var result = await _service.UpdateCourseAsync(course);
            return Ok(result);
        }

        [HttpDelete("courses/{id}")]
        [Authorize(Policy = "FullAccess")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _service.DeleteCourseAsync(id);
            return Ok(result);
        }

        // Department CRUD
        [HttpGet("departments")]
        [Authorize]
        public async Task<IActionResult> GetAllDepartments() =>
            Ok(await _service.GetAllDepartmentsAsync());

        [HttpGet("departments/{id}")]
        [Authorize]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _service.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        [HttpPost("departments")]
        [Authorize(Policy = "FullAccess")]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentModel department)
        {
            var result = await _service.AddDepartmentAsync(department);
            return Ok(result);
        }

        [HttpPut("departments/{id}")]
        [Authorize(Policy = "FullAccess")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentModel department)
        {
            department.DepartmentId = id;
            var result = await _service.UpdateDepartmentAsync(department);
            return Ok(result);
        }

        [HttpDelete("departments/{id}")]
        [Authorize(Policy = "FullAccess")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _service.DeleteDepartmentAsync(id);
            return Ok(result);
        }
    }
}