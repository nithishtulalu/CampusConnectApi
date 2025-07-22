using CampusConnectAPI.DTOs.FeesTransactions;
using CampusConnectAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectAPI.Repositories.implementation
{
    public class FeeTransactionRepository :IFeeTransactionRepository
    {
        private readonly ApplicationDbContext _context;
        public FeeTransactionRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<FessResponseDto> GetUserFeeAsync(Guid userId)
        {
            try
            {
                var fee= await _context.Fees
                    .Include(f=>f.Transactions)
                    .FirstOrDefaultAsync(f=>f.UserId==userId);

                if (fee == null)
                    return null;

            }
            catch (Exception ex)
            {
            }
        }
        public async Task<TransactionResponseDto> MakePaymentAsync(TransactionRequestDto dto)
        {
            try
            {

            }
            catch (Exception ex)
            {
            }

        }
        public async Task<List<TransactionResponseDto>> GetUserTransactionAsync(Guid userId)
        {
            try
            {

            }
            catch (Exception ex)
            {
            }
        }
    }
}
