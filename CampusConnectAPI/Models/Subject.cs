using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Guid CourseId { get; set; }

        public Course Course { get; set; }
    }
}
