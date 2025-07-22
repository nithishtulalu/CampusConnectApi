using CampusConnectAPI.DTOs.SubGrade;
using CampusConnectAPI.Models;
using CampusConnectAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectAPI.Repositories.implementation
{
    public class SubjectGradeRepository : ISubjectGradeRepository
    {
        private readonly ApplicationDbContext _context;
        public SubjectGradeRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<SubjectResponseDto>> GetAllSubjectsAsync()
        {
            try
            {
                var subjects = await _context.Subjects.Include(s => s.Course).ToListAsync();
                return subjects.Select(s => new SubjectResponseDto
                {
                    SubjectId = s.SubjectId,
                    SubjectName = s.SubjectName,
                    CourseName = s.Course?.CourseName ?? "Unassigned"

                }).ToList();
            }
            catch (Exception ex)
            {
                return new List<SubjectResponseDto>();
            }

        }

        public async Task<SubjectResponseDto> AddSubjectAsync(CreateSubjectDto dto)
        {
            try
            {
                var subject = new Subject
                {
                    SubjectId = Guid.NewGuid(),
                    SubjectName = dto.SubjectName,
                    CourseId = dto.CourseId,
                };
                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();
                var course = await _context.Courses.FindAsync(dto.CourseId);
                return new SubjectResponseDto
                {
                    SubjectId = subject.SubjectId,
                    SubjectName = subject.SubjectName,
                    CourseName = course?.CourseName ?? "Unassigned"
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<GradeResponseDto>> GetGradesForUserAsync(Guid userId)
        {
            try
            {
                var grades = await _context.Grades
                    .Include(g => g.Subject)
                    .Include(g => g.Enrollment)
                    .ThenInclude(e => e.Course)
                    .Where(g => g.Enrollment.UserId == userId)
                    .ToListAsync();
                return grades.Select(g => new GradeResponseDto
                {
                    GradeId = g.GradeId,
                    CourseName = g.Enrollment.Course?.CourseName ?? "Unknown",
                    SubjectName = g.Subject?.SubjectName ?? "Unknown",
                    Marks = g.Marks,
                    GradeValue = g.GradeValue,
                    GradedOn = DateTime.UtcNow
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<GradeResponseDto> SubmitGradeAsync(SubmitGradeDto dto)
        {
            try
            {
                var enrollment= await _context.Enrollments
                    .Include(e=>e.Course)
                    .FirstOrDefaultAsync(e=>e.EnrollmentId == dto.EnrollmentId);

                var subject = await _context.Subjects.FindAsync(dto.SubjectId);
                if (enrollment == null || subject == null)
                    return null;

                var grade = new Grade
                {
                    GradeId = Guid.NewGuid(),
                    EnrollmentId = dto.EnrollmentId,
                    SubjectId = dto.SubjectId,
                    Marks = dto.Marks,
                    GradeValue = dto.GradeValue,

                };
                _context.Grades.Add(grade);
                await _context.SaveChangesAsync();
                return new GradeResponseDto
                {
                    GradeId = grade.GradeId,
                    CourseName = enrollment.Course?.CourseName ?? "Unknown",
                    SubjectName = subject.SubjectName ?? "Unknown",
                    Marks = dto.Marks,
                    GradeValue = dto.GradeValue,

                };
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}