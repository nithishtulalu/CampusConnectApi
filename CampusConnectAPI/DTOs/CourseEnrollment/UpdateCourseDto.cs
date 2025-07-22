namespace CampusConnectAPI.DTOs.CourseEnrollment
{
    public class UpdateCourseDto
    {
        public string CourseName {  get; set; }
        public int Credits { get; set; }
        public Guid FacultyId { get; set; }
    }
}
