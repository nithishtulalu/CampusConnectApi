using CampusConnectAPI.DTOs.CourseEnrollment;
using CampusConnectAPI.Models;
using CampusConnectAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectAPI.Repositories.implementation
{
    public class CourseEnrollmentRepository : ICourseEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseEnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseResponseDto>> GetAllCoursesAsync()
        {
            try
            {
                var courses = await _context.Courses.Include(c => c.Faculty).ToListAsync();
                return courses.Select(c => new CourseResponseDto
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    Credits = c.Credits,
                    FacultyName = c.Faculty?.FullName ?? "Unassigned"
                }).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<CourseResponseDto> GetCourseByIdAsync(Guid id)
        {
            try
            {
                var c = await _context.Courses.Include(c => c.Faculty).FirstOrDefaultAsync(c => c.CourseId == id);
                return c == null ? null : new CourseResponseDto
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    Credits = c.Credits,
                    FacultyName = c.Faculty?.FullName ?? "Unassigned"
                };
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public async Task<CourseResponseDto> CreateCourseAsync(CreateCourseDto createCourseDto)
        {
            try
            {
                var course = new Course
                {
                    CourseId = Guid.NewGuid(),
                    CourseName = createCourseDto.CourseName,
                    Credits = createCourseDto.Credits,
                    FacultyId = createCourseDto.FacultyId,
                };
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                var faculty = await _context.Users.FindAsync(createCourseDto.FacultyId);
                return new CourseResponseDto
                {

                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    Credits = course.Credits,
                    FacultyName = course.Faculty?.FullName ?? "Unassigned"


                };
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<CourseResponseDto> UpdateCourseAsync(Guid courseId, UpdateCourseDto updateCourseDto)
        {
            try
            {
                var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
                if (course == null)
                    return null;
                course.CourseName = updateCourseDto.CourseName;
                course.Credits = updateCourseDto.Credits;
                course.FacultyId = updateCourseDto.FacultyId;

                await _context.SaveChangesAsync();
                var faculty = await _context.Users.AnyAsync(u=>u.UserId == updateCourseDto.FacultyId && u.Role.RoleName== "Faculty");
                if (!faculty)
                    throw new Exception("invalid facuility id");
                return new CourseResponseDto
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    Credits = course.Credits,
                    FacultyName = course.Faculty?.FullName ?? "Unassigned"
                };
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<EnrollmentResponseDto> EnrollUserAsync(EnrollDto enrollDto)
        {
            try
            {
                var enrollment = new Enrollment
                {
                    EnrollmentId = Guid.NewGuid(),
                    UserId = enrollDto.UserId,
                    CourseId = enrollDto.CourseId
                };
                _context.Enrollments.Add(enrollment);
                await _context.SaveChangesAsync();

                var course = await _context.Courses.FindAsync(enrollDto.CourseId);
                return new EnrollmentResponseDto
                {
                    EnrollmentId = enrollment.EnrollmentId,
                    CourseName = course?.CourseName ?? "Unknown",
                    EnrolledOn = DateTime.UtcNow

                };
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<EnrollmentResponseDto>> GetEnrollmentsByUserAsync(Guid userId)
        {
            try
            {
                var enrollments = await _context.Enrollments.Include(e => e.Course)
                                                            .Where(e=>e.UserId == userId)
                                                            .ToListAsync();
                return enrollments.Select(e=> new EnrollmentResponseDto
                {
                    EnrollmentId = e.EnrollmentId,
                    CourseName=e.Course.CourseName,
                    EnrolledOn = DateTime.UtcNow
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}