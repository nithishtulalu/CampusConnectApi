using CampusConnectAPI.DTOs.FeesTransactions;

namespace CampusConnectAPI.Services.Interfaces
{
    public interface IFeeTransactionService
    {
        Task<FessResponseDto> GetUserFeeAsync(Guid userId);
        Task<TransactionResponseDto> MakePaymentByStudentAsync(StudentPaymnetRequestDto dto);
        Task<List<TransactionResponseDto>> GetUserTransactionAsync(Guid userId);
    }
}
