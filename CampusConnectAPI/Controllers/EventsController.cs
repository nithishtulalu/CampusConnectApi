using CampusConnectAPI.DTOs.EventRegistactionDto;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;
        public EventsController(IEventService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetEvent()
        {
            var events = await _service.GetUpcomingAsync();
            return Ok(events);

        }

        [Authorize(Roles ="Student")]
        [HttpPost("rigister")]
        public async Task<IActionResult> RegsterForEvent(EventRegisterRequestDto dto)
        {
            var result = await _service.RegisterUserAsync(dto);
            return result == null
                ? BadRequest("invalid registration or alredy registered.")
                : Ok(result);
        }

        [Authorize(Roles = "Student")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserRegistreations(Guid userId)
        {
            var registrations = await _service.GetUserRegisterUserAsync(userId);
            return Ok(registrations);
        }
    }
}
