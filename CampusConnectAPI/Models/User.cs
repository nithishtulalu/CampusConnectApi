using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public ICollection<UserLogin> Logins { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<EventRegistration> EventRegistrations { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
