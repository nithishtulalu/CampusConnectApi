namespace CampusConnectAPI.DTOs.CourseEnrollment
{
    public class CreateCourseDto
    {
        public string CourseName {  get; set; }
        public int Credits {  get; set; }
        public Guid FacultyId { get; set; }
    }
}
