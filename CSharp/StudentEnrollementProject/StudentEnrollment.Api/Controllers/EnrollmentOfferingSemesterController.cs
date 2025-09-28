using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.Service.Interfaces;
using StudentEnrollment.Service.Models;
using System.Threading.Tasks;

namespace StudentEnrollment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentOfferingSemesterController : ControllerBase
    {
        private readonly IEnrollmentOfferingSemesterService _service;
        public EnrollmentOfferingSemesterController(IEnrollmentOfferingSemesterService service)
        {
            _service = service;
        }

        // Enrollment CRUD
        [HttpGet("enrollments")]
        public async Task<IActionResult> GetAllEnrollments() =>
            Ok(await _service.GetAllEnrollmentsAsync());

        [HttpGet("enrollments/{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var enrollment = await _service.GetEnrollmentByIdAsync(id);
            if (enrollment == null) return NotFound();
            return Ok(enrollment);
        }

        [HttpPost("enrollments")]
        public async Task<IActionResult> AddEnrollment([FromBody] EnrollmentModel enrollment)
        {
            var result = await _service.AddEnrollmentAsync(enrollment);
            return Ok(result);
        }

        [HttpPut("enrollments/{id}")]
        public async Task<IActionResult> UpdateEnrollment(int id, [FromBody] EnrollmentModel enrollment)
        {
            enrollment.EnrollmentId = id;
            var result = await _service.UpdateEnrollmentAsync(enrollment);
            return Ok(result);
        }

        [HttpDelete("enrollments/{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var result = await _service.DeleteEnrollmentAsync(id);
            return Ok(result);
        }

        // ClassOffering CRUD
        [HttpGet("classofferings")]
        public async Task<IActionResult> GetAllClassOfferings() =>
            Ok(await _service.GetAllClassOfferingsAsync());

        [HttpGet("classofferings/{id}")]
        public async Task<IActionResult> GetClassOfferingById(int id)
        {
            var offering = await _service.GetClassOfferingByIdAsync(id);
            if (offering == null) return NotFound();
            return Ok(offering);
        }

        [HttpPost("classofferings")]
        public async Task<IActionResult> AddClassOffering([FromBody] ClassOfferingModel offering)
        {
            var result = await _service.AddClassOfferingAsync(offering);
            return Ok(result);
        }

        [HttpPut("classofferings/{id}")]
        public async Task<IActionResult> UpdateClassOffering(int id, [FromBody] ClassOfferingModel offering)
        {
            offering.ClassOfferingId = id;
            var result = await _service.UpdateClassOfferingAsync(offering);
            return Ok(result);
        }

        [HttpDelete("classofferings/{id}")]
        public async Task<IActionResult> DeleteClassOffering(int id)
        {
            var result = await _service.DeleteClassOfferingAsync(id);
            return Ok(result);
        }

        // Semester CRUD
        [HttpGet("semesters")]
        public async Task<IActionResult> GetAllSemesters() =>
            Ok(await _service.GetAllSemestersAsync());

        [HttpGet("semesters/{id}")]
        public async Task<IActionResult> GetSemesterById(int id)
        {
            var semester = await _service.GetSemesterByIdAsync(id);
            if (semester == null) return NotFound();
            return Ok(semester);
        }

        [HttpPost("semesters")]
        public async Task<IActionResult> AddSemester([FromBody] SemesterModel semester)
        {
            var result = await _service.AddSemesterAsync(semester);
            return Ok(result);
        }

        [HttpPut("semesters/{id}")]
        public async Task<IActionResult> UpdateSemester(int id, [FromBody] SemesterModel semester)
        {
            semester.SemesterId = id;
            var result = await _service.UpdateSemesterAsync(semester);
            return Ok(result);
        }

        [HttpDelete("semesters/{id}")]
        public async Task<IActionResult> DeleteSemester(int id)
        {
            var result = await _service.DeleteSemesterAsync(id);
            return Ok(result);
        }
    }
}