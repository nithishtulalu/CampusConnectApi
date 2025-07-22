using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class EventRegistration
    {
        [Key]
        public Guid RegistrationId { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTime RegisteredAt { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}
