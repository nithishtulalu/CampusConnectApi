using CampusConnectAPI.DTOs.EventRegistactionDto;

namespace CampusConnectAPI.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<List<EventResponseDto>> GetUpcomingAsync();
        Task<EventRegistrationDto> RegisterUserAsync(EventRegisterRequestDto dto);
        Task<List<EventRegistrationDto>> GetUserRegisterUserAsync(Guid userId);
    }
}
