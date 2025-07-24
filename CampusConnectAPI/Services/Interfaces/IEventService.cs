using CampusConnectAPI.DTOs.EventRegistactionDto;

namespace CampusConnectAPI.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<EventResponseDto>> GetUpcomingAsync();
        Task<EventRegistrationDto> RegisterUserAsync(EventRegisterRequestDto dto);
        Task<List<EventRegistrationDto>> GetUserRegisterUserAsync(Guid userId);
    }
}
