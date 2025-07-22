using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid CreatedBy { get; set; }

        public User Creator { get; set; }
        public ICollection<EventRegistration> Registrations { get; set; }
    }
}
