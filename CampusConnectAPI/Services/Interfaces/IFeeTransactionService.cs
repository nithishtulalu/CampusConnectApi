using CampusConnectAPI.DTOs.FeesTransactions;

namespace CampusConnectAPI.Services.Interfaces
{
    public interface IFeeTransactionService
    {
        Task<FessResponseDto> GetUserFeeAsync(Guid userId);
        Task<TransactionResponseDto> MakePaymentAsync(TransactionRequestDto dto);
        Task<List<TransactionResponseDto>> GetUserTransactionAsync(Guid userId);
    }
}
