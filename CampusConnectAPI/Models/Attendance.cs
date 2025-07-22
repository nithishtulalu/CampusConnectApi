using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Attendance
    {
        [Key]
        public Guid AttendanceId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        public Subject Subject { get; set; }
        public User User { get; set; }
    }
}
