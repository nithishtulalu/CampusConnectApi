using CampusConnectAPI.DTOs.Attendance;
using CampusConnectAPI.Models;
using CampusConnectAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectAPI.Repositories.implementation
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<AttendanceResponseDto> MarkAttendanceAsync(MarkAttendanceDto dto)
        {
            try
            {
                var subject = await _context.Subjects.FindAsync(dto.SubjectId);
                var user = await _context.Users.FindAsync(dto.UserId);
                if (subject == null || user == null)
                    return null;
                var attendance = new Attendance
                {
                    AttendanceId = Guid.NewGuid(),
                    UserId = dto.UserId,
                    SubjectId = dto.SubjectId,
                    Date = dto.Date.Date,
                    Status = dto.Status
                };
                _context.Attendances.Add(attendance);
                await _context.SaveChangesAsync();

                return new AttendanceResponseDto
                {
                    AttendanceId = attendance.AttendanceId,
                    SubjectName = subject.SubjectName,
                    Date = attendance.Date,
                    Status = attendance.Status
                };

            }


            catch (Exception ex)
            {
                return null;

            }


        }

        public async Task<List<AttendanceResponseDto>> GetAllAttendancesAsync(Guid userId)
        {
            try
            {
                var attendanceList= await _context.Attendances
                    .Include(a=>a.Subject)
                    .Where(a=>a.UserId == userId)
                    .OrderByDescending(a=>a.Date)
                    .ToListAsync();

                return attendanceList.Select(a=> new AttendanceResponseDto
                {
                    AttendanceId= a.AttendanceId,
                    SubjectName=a.Subject?.SubjectName ??"Unknow",
                    Date = a.Date,
                    Status = a.Status
                }).ToList();
            }
            catch (Exception ex)
            {
                return new List<AttendanceResponseDto>();
            }
        }
    }
}