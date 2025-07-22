namespace CampusConnectAPI.DTOs.SubGrade
{
    public class CreateSubjectDto
    {
        public string SubjectName { get; set; }
        public Guid CourseId { get; set; }
    }
}
