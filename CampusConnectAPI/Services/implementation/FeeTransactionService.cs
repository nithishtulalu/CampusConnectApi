using CampusConnectAPI.DTOs.FeesTransactions;
using CampusConnectAPI.Repositories.Interfaces;
using CampusConnectAPI.Services.Interfaces;

namespace CampusConnectAPI.Services.implementation
{
    public class FeeTransactionService : IFeeTransactionService
    {
        private readonly IFeeTransactionRepository _repository;
        public FeeTransactionService(IFeeTransactionRepository repository)
        {
            _repository=repository;
        }
        public async Task<FessResponseDto> GetUserFeeAsync(Guid userId)=>
            await _repository.GetUserFeeAsync(userId);
        public async Task<TransactionResponseDto> MakePaymentAsync(TransactionRequestDto dto) =>
            await _repository.MakePaymentAsync(dto);

        public async Task<List<TransactionResponseDto>> GetUserTransactionAsync(Guid userId)=>
            await _repository.GetUserTransactionAsync(userId);
    }
}
