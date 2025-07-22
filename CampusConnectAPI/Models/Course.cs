using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        public string CourseName {  get; set; }
        public  int Credits {  get; set; }
        public  Guid FacultyId { get; set; }

        public User Faculty { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
