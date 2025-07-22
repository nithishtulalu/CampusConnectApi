namespace CampusConnectAPI.DTOs.CourseEnrollment
{
    public class CourseResponseDto
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credits {  get; set; }
        public string FacultyName {  get; set; }

    }
}
