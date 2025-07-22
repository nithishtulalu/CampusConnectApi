using System.Transactions;
using CampusConnectAPI.DTOs.FeesTransactions;
using CampusConnectAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using CampusConnectAPI.Models;

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
                var totalPaid = fee.Transactions?.Sum(t => t.AmountPaid) ?? 0;
                return new FessResponseDto
                {
                    feeId = fee.FeeId,
                    AmountDue = fee.AmountDue,
                    DueDate = fee.DueDate,
                    TotalPaid = totalPaid
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<TransactionResponseDto> MakePaymentAsync(TransactionRequestDto dto)
        {
            try
            {
        
                var fee= await _context.Fees.FindAsync(dto.FeeId);
                if (fee == null)
                    return null;

                var transaction = new TransactionRecord
                {
                    TransactionId=Guid.NewGuid(),
                    FeeId=dto.FeeId,
                    AmountPaid=dto.AmountPaid,
                    PaymentDate=DateTime.UtcNow,
                    PaymentMethod=dto.PaymentMethod

                };
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                return new TransactionResponseDto
                {
                    TransactionId = transaction.TransactionId,
                    AmountPaid = transaction.AmountPaid,
                    PaymentMethod = transaction.PaymentMethod,
                    PaymentDate = transaction.PaymentDate,
                };
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<List<TransactionResponseDto>> GetUserTransactionAsync(Guid userId)
        {
            try
            {
                var fee=await _context.Fees
                    .Include(f=>f.Transactions)
                    .FirstOrDefaultAsync(f=>f.UserId==userId);

                return fee?.Transactions.Select(t=> new TransactionResponseDto
                {
                    TransactionId=t.TransactionId,
                    AmountPaid=t.AmountPaid,
                    PaymentMethod=t.PaymentMethod,
                    PaymentDate=t.PaymentDate

                }).ToList() ?? new List<TransactionResponseDto>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
