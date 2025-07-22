using CampusConnectAPI.DTOs.CourseEnrollment;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseEnrollmentController : ControllerBase
    {
        private readonly ICourseEnrollmentService _service;
        public CourseEnrollmentController(ICourseEnrollmentService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("Courses")]
        public async Task<IActionResult> GetCourses()=>
            Ok(await _service.GetAllCoursesAsync());

        [HttpGet]
        [Route("Courses/{id}")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var course= await _service.GetCourseByIdAsync(id);
            return  course == null ? NotFound() : Ok(course);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Course")]
        public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
        {
            var created=await  _service.CreateCourseAsync(dto);

            return CreatedAtAction(nameof(GetCourseById),new { id=created.CourseId} ,created);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(Guid  id,UpdateCourseDto dto)
        {
            var update= await _service.UpdateCourseAsync(id,dto);
            return update == null ? NotFound() : Ok(update);
        }


        [Authorize(Roles = "Student")]
        [HttpPost]
        [Route("enrollments")]
        public async Task<IActionResult> EnrollUser(EnrollDto dto)
        {
            var enrolled= await _service.EnrollUserAsync(dto);
            return Ok(enrolled);
        }

        
        [HttpGet("enrollments/user/{userId}")]
        public async Task<IActionResult> GetUserEnrollments(Guid userId)
        {
            var enrollments=  await _service.GetUserEnrollmentsAsync(userId);
            return Ok(enrollments);
        }
       
       


    }
}
