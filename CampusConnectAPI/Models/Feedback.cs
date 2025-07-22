using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Feedback
    {
        [Key]
        public Guid FeedbackId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime SubmittedAt { get; set; }

        public User User { get; set; }
    }
}
