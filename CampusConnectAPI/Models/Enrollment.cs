using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace CampusConnectAPI.Models
{
    public class Enrollment
    {
        [Key]
        public Guid EnrollmentId { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
