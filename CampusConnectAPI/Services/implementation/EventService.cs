using CampusConnectAPI.DTOs.EventRegistactionDto;
using CampusConnectAPI.Repositories.Interfaces;
using CampusConnectAPI.Services.Interfaces;

namespace CampusConnectAPI.Services.implementation
{
    public class EventService:IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository repository)
        {
            _eventRepository = repository;
        }

        public async Task<List<EventResponseDto>> GetUpcomingAsync()=>
            await _eventRepository.GetUpcomingAsync();

        public async Task<EventRegistrationDto> RegisterUserAsync(EventRegisterRequestDto dto) =>
            await _eventRepository.RegisterUserAsync(dto);

        public async Task<List<EventRegistrationDto>> GetUserRegisterUserAsync(Guid userId)=>
            await _eventRepository.GetUserRegisterUserAsync(userId);                            
    }
}
