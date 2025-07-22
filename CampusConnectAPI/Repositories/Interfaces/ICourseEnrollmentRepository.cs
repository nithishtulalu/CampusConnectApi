using CampusConnectAPI.DTOs.CourseEnrollment;
using CampusConnectAPI.Models;

namespace CampusConnectAPI.Repositories.Interfaces
{
    public interface ICourseEnrollmentRepository
    {
        //course action
        Task<List<CourseResponseDto>> GetAllCoursesAsync();
        Task<CourseResponseDto> GetCourseByIdAsync(Guid id);
        Task<CourseResponseDto> CreateCourseAsync(CreateCourseDto createCourseDto);
        Task<CourseResponseDto> UpdateCourseAsync(Guid  courseId, UpdateCourseDto updateCourseDto);

        //Enrollment action

        Task<EnrollmentResponseDto> EnrollUserAsync(EnrollDto  enrollDto);
        Task<List<EnrollmentResponseDto>> GetEnrollmentsByUserAsync(Guid userId);
    }
}
