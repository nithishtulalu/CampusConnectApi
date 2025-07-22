using CampusConnectAPI.DTOs.CourseEnrollment;
using CampusConnectAPI.Repositories.Interfaces;
using CampusConnectAPI.Services.Interfaces;

namespace CampusConnectAPI.Services.implementation
{
    public class CourseEnrollmentService : ICourseEnrollmentService
    {
        private readonly ICourseEnrollmentRepository _repo;
        public CourseEnrollmentService(ICourseEnrollmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CourseResponseDto>> GetAllCoursesAsync()=>
            await _repo.GetAllCoursesAsync();
        public async Task<CourseResponseDto> GetCourseByIdAsync(Guid id) =>
            await _repo.GetCourseByIdAsync(id);

        public async Task<CourseResponseDto> CreateCourseAsync(CreateCourseDto dto) =>
            await _repo.CreateCourseAsync(dto);
        public async Task<CourseResponseDto> UpdateCourseAsync(Guid courseId, UpdateCourseDto dto) =>
            await _repo.UpdateCourseAsync(courseId, dto);

        public async Task<EnrollmentResponseDto> EnrollUserAsync(EnrollDto dto) =>
            await _repo.EnrollUserAsync(dto);
        public async Task<List<EnrollmentResponseDto>> GetUserEnrollmentsAsync(Guid userId)=>
            await _repo.GetEnrollmentsByUserAsync(userId);
    }
}
