using CampusConnectAPI.DTOs.Library;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService library)
        {
            _libraryService = library;
        }
        [Authorize]
        [HttpGet("books")]
        public async Task<IActionResult> GetAvailableBooks()
        {
            var books= await _libraryService.GetAvailableBooksAsync();
            return Ok(books);
        }

        [Authorize (Roles ="Student")]
        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook(BorrowRequestDto dto)
        {
            var borrow= await _libraryService.BorrowBookAsync(dto);
            return borrow == null
                ?BadRequest("Book unavailable or user not allowed.")
                : Ok(borrow);

        }

        [Authorize(Roles ="Student")]
        [HttpGet("borrow/user/{userId}")]
        public async Task<IActionResult> GetBorrowHistory(Guid userId)
        {
            var history=await _libraryService.GetBorrowHistoryAsync(userId);
            return Ok(history);
        }


    }
}
