using CampusConnectAPI.DTOs.FeesTransactions;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeTransactionController : ControllerBase
    {
        private readonly IFeeTransactionService _Service;
        public FeeTransactionController(IFeeTransactionService service)
        {
            _Service = service;
        }

        [Authorize]
        [HttpGet("fees/user/{userId}")]
        public async Task<IActionResult> GetUserFee(Guid userId)
        {
            var fee= await _Service.GetUserFeeAsync(userId);
            return fee== null ? NotFound() : Ok(fee);
        }

        [Authorize (Roles ="Student")]
        [HttpPost("transaction")]
        public async Task<IActionResult> MakePayment(TransactionRequestDto dto)
        {
            var payment= await _Service.MakePaymentAsync(dto);
            return payment == null ? BadRequest("Fee Record not Found") : Ok(payment);
        }

        [Authorize]
        [HttpGet("transaction/user/{userId}")]
        public async Task<IActionResult> GetUserTransaction(Guid userId)
        {
            var transactions= await _Service.GetUserTransactionAsync(userId);
            return transactions == null ? NotFound("Not Found") : Ok(transactions);
        }
    }
}
