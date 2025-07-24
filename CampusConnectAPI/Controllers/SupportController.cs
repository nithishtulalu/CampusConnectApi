using CampusConnectAPI.DTOs.FeedBacks;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService _supportService;
        public SupportController(ISupportService support)
        {
            _supportService = support;
        }


        [Authorize]
        [HttpPost("contacts")]
        public async Task<IActionResult> SubmitContact(ContactRequestDto dto)
        {
            var  success= await _supportService.SubmitContactAsync(dto);
            return success ? Ok(success) : BadRequest("Faild");
        }

        [Authorize(Roles ="Student")]
        [HttpPost("feedbacks")]
        public async Task<IActionResult> SubmitFeedbackAsync(FeedbackRequestDto dto)
        {
            var sucess=  await _supportService.SubmitFeedbackAsync(dto);
            return sucess ? Ok(sucess) : BadRequest("faild");

        }

        [Authorize]
        [HttpGet("faqs")]
        public async Task<IActionResult> GetFaqs()
        {
            var faqs= await _supportService.GetAllFaqAsync();
            return Ok(faqs);
        }
    }
}
