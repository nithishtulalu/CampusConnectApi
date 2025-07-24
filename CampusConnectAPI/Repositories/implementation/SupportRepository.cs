using CampusConnectAPI.DTOs.FeedBacks;
using CampusConnectAPI.Models;
using CampusConnectAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectAPI.Repositories.implementation
{
    public class SupportRepository:ISupportRepository
    {
        private readonly ApplicationDbContext _context;
        public SupportRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<bool> SubmitContactAsync(ContactRequestDto dto)
        {
            try
            {
                var contact = new Contact
                {
                    ContactId = Guid.NewGuid(),
                    UserId = dto.UserId,
                    Message = dto.Message,
                    SubmittedAt = DateTime.UtcNow

                };
                _context.Contacts.Add(contact);
                return await _context.SaveChangesAsync() > 0;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
       public async  Task<bool> SubmitFeedbackAsync(FeedbackRequestDto dto)
        {
            try
            {
                var feedback = new Feedback
                {
                    FeedbackId = Guid.NewGuid(),
                    UserId = dto.UserId,
                    Rating = dto.Rating,
                    Comments = dto.Comments,
                    SubmittedAt = DateTime.UtcNow
                };

                _context.Feedbacks.Add(feedback);
                return await  _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<List<FaqResponseDto>> GetAllFaqAsync()
        {
            try
            {
                var faqs= await _context.Faqs.ToListAsync();
                return faqs.Select(f => new FaqResponseDto
                {
                    FaqId = f.FaqId,
                    Qustion = f.Question,
                    Answer = f.Answer,
                }).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
