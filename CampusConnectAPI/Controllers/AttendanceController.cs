using CampusConnectAPI.DTOs.Attendance;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;

        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Faculty")]
        [HttpPost("mark")]
        public async Task<IActionResult> MarkAttendance(MarkAttendanceDto dto)
        {
            var result= await  _service.MarkAttendanceAsync(dto);
            return result ==null ? BadRequest("user or  subject not found"):Ok(result);

        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserAttendance(Guid userId)
        {
            var attendance= await _service.GetAllAttendancesAsync(userId);
            return Ok(attendance);
        }

    }
}
