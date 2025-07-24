using CampusConnectAPI.DTOs.FeedBacks;

namespace CampusConnectAPI.Repositories.Interfaces
{
    public interface ISupportRepository
    {
        Task<bool> SubmitContactAsync(ContactRequestDto dto);
        Task<bool> SubmitFeedbackAsync(FeedbackRequestDto dto);
        Task<List<FaqResponseDto>> GetAllFaqAsync();
    }
}
