using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Grade
    {
        [Key]
        public Guid GradeId { get; set; }
        public Guid EnrollmentId { get; set; }
        public Guid SubjectId { get; set; }
        public int Marks { get; set; }
        public string GradeValue { get; set; }

        public Enrollment Enrollment { get; set; }
        public Subject Subject { get; set; }
    }
}
