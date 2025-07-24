using CampusConnectAPI.DTOs.FeedBacks;

namespace CampusConnectAPI.Services.Interfaces
{
    public interface ISupportService
    {
        Task<bool> SubmitContactAsync(ContactRequestDto dto);
        Task<bool> SubmitFeedbackAsync(FeedbackRequestDto dto);
        Task<List<FaqResponseDto>> GetAllFaqAsync();
    }
}
