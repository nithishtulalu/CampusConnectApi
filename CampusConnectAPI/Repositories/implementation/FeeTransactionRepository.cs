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
        public async Task<TransactionResponseDto> MakePaymentByStudentAsync(StudentPaymnetRequestDto dto)
        {
            try
            {
                var user= await _context.Users
                    .Include(u=>u.Role)
                    .FirstOrDefaultAsync(u=>u.UserId==dto.UserId);
                if (user == null || user.Role.RoleName != "Student")
                    return null;
                var enrollment= await _context.Enrollments
                    .Include(e=>e.Course)
                    .FirstOrDefaultAsync(e=>e.UserId==dto.UserId);

                if(enrollment == null)
                    return  null ;
                int creditrate = 10000;
                int credits=enrollment.Course.Credits;
                int calacluteDue=credits+creditrate;

                var fee= await _context.Fees.FirstOrDefaultAsync(f=>f.UserId==dto.UserId);
                if(fee == null)
                {
                    fee = new Fee
                    {
                        FeeId = Guid.NewGuid(),
                        UserId = dto.UserId,
                        AmountDue = calacluteDue,
                        DueDate = DateTime.UtcNow.AddDays(40)
                    };
                    _context.Fees.Add(fee);
                    await _context.SaveChangesAsync();
                }
                var transaction = new TransactionRecord
                {
                    TransactionId = Guid.NewGuid(),
                    FeeId = fee.FeeId,
                    AmountPaid = dto.AmountPaid,
                    PaymentDate = DateTime.UtcNow,
                    PaymentMethod = dto.PaymentMethod
                };
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                return new TransactionResponseDto
                {
                    TransactionId = transaction.TransactionId,
                    AmountPaid = transaction.AmountPaid,
                    PaymentDate = transaction.PaymentDate,
                    PaymentMethod = transaction.PaymentMethod
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
