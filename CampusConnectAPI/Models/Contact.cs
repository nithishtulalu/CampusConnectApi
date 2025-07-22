using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedAt { get; set; }

        public User User { get; set; }
    }
}
