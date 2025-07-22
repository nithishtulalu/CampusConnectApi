using CampusConnectAPI.DTOs.CourseEnrollment;

namespace CampusConnectAPI.Services.Interfaces
{
    public interface ICourseEnrollmentService
    {
        Task<List<CourseResponseDto>> GetAllCoursesAsync();
        Task<CourseResponseDto> GetCourseByIdAsync(Guid id);
        Task<CourseResponseDto> CreateCourseAsync(CreateCourseDto dto);
        Task<CourseResponseDto> UpdateCourseAsync(Guid courseId, UpdateCourseDto dto);

        Task<EnrollmentResponseDto> EnrollUserAsync(EnrollDto dto);
        Task<List<EnrollmentResponseDto>> GetUserEnrollmentsAsync(Guid userId);
    }
}
