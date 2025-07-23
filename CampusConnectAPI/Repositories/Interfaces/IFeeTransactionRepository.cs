using CampusConnectAPI.DTOs.FeesTransactions;

namespace CampusConnectAPI.Repositories.Interfaces
{
    public interface IFeeTransactionRepository
    {
        Task<FessResponseDto> GetUserFeeAsync(Guid userId);
        Task<TransactionResponseDto> MakePaymentByStudentAsync(StudentPaymnetRequestDto dto);
        Task<List<TransactionResponseDto>> GetUserTransactionAsync(Guid userId);
    }
}
