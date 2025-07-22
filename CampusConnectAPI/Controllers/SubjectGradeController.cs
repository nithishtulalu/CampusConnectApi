using CampusConnectAPI.DTOs.SubGrade;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectGradeController : ControllerBase
    {
        private readonly ISubjectGradeService _service;
        public SubjectGradeController(ISubjectGradeService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetSubject()
        {
            var subjects= await _service.GetAllSubjectsAsync();
            return Ok(subjects);
        }
        [Authorize(Roles ="Admin")]
        [HttpPost("subjects")]
        public async Task<IActionResult> AddSubjects(CreateSubjectDto dto)
        {
            var added= await _service.AddSubjectAsync(dto);
            return CreatedAtAction(nameof(GetSubject), new {id=added.SubjectId}, added);    
        }
        [Authorize]
        [HttpGet("grades/user/{userId}")]
        public async Task<IActionResult> GetUserGrade(Guid userId)
        {
            var grades = await _service.GetGradesForUserAsync(userId);
            return Ok(grades);
        }
        [Authorize(Roles = "Faculty")]
        [HttpPost("grades")]
        public async Task<IActionResult> SubmitGraf(SubmitGradeDto dto)
        {
            var grade= await _service.SubmitGradeAsync(dto);
            return grade == null ? BadRequest("invalid Enrollment or subject"):Ok(grade);
        }
    }
}
