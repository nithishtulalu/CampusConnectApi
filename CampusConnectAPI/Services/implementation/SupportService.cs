using CampusConnectAPI.DTOs.FeedBacks;
using CampusConnectAPI.Repositories.Interfaces;
using CampusConnectAPI.Services.Interfaces;

namespace CampusConnectAPI.Services.implementation
{
    public class SupportService:ISupportService
    {
        private readonly ISupportRepository _repository;
        public SupportService(ISupportRepository repository)
        {
            _repository = repository;

        }

       public async  Task<bool> SubmitContactAsync(ContactRequestDto dto)=>
            await _repository.SubmitContactAsync(dto);
       public async  Task<bool> SubmitFeedbackAsync(FeedbackRequestDto dto)=>
            await _repository.SubmitFeedbackAsync(dto);

       public async Task<List<FaqResponseDto>> GetAllFaqAsync()=>
            await _repository.GetAllFaqAsync();
    }
}
