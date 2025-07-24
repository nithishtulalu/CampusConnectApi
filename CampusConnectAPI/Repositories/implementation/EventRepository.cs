using CampusConnectAPI.DTOs.EventRegistactionDto;
using CampusConnectAPI.Models;
using CampusConnectAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectAPI.Repositories.implementation
{
    public class EventRepository:IEventRepository
    {

        private readonly ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<EventResponseDto>> GetUpcomingAsync()
        {
            try
            {
                var now= DateTime.UtcNow;
                var  events= await _context.Events
                    .Where(e=>e.Date >= now)
                    .OrderBy(e=>e.Date)
                    .ToListAsync();

                return events.Select(e => new EventResponseDto
                {
                    EventId = e.EventId,
                    Title = e.Title,
                    Description = e.Description,
                    Date = e.Date
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async  Task<EventRegistrationDto> RegisterUserAsync(EventRegisterRequestDto dto)
        {
            try
            {
                var user = await _context.Users.Include(u=>u.Role)
                    .FirstOrDefaultAsync(u=>u.UserId ==dto.UserId);
                if (user == null || user.Role.RoleName != "Student")
                    return null;

                var eventEntity= await _context.Events.FindAsync(dto.EventId);
                if (eventEntity == null)
                    return null;

                var alreadyRegisteres= await _context.EventsRegistrations
                    .AnyAsync(r=>r.UserId ==dto.UserId && r.EventId == dto.EventId );
                if (alreadyRegisteres)
                    return null;

                var registration = new EventRegistration
                {
                    RegistrationId = Guid.NewGuid(),
                    UserId = dto.UserId,
                    EventId = dto.EventId,
                    RegisteredAt = DateTime.UtcNow
                };
                _context.EventsRegistrations.Add(registration);
                await _context.SaveChangesAsync();

                return new EventRegistrationDto
                {
                    RegistrationId = registration.RegistrationId,
                    EventTitle = eventEntity.Title,
                    RegisteredAt = registration.RegisteredAt
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<EventRegistrationDto>> GetUserRegisterUserAsync(Guid userId)
        {
            try
            {
                var registrations= await _context.EventsRegistrations
                    .Include(r=>r.EventId)
                    .Where(r=>r.UserId==userId&& r.EventId !=null)
                    .OrderByDescending(r=>r.RegisteredAt)
                    .ToListAsync();
                if (registrations == null || !registrations.Any())
                    return new List<EventRegistrationDto>();
                return registrations.Select(r=> new EventRegistrationDto
                {
                    RegistrationId = r.RegistrationId,
                    EventTitle=r.Event.Title,
                    RegisteredAt = r.RegisteredAt
                }).ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
