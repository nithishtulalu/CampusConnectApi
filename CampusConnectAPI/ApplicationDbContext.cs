using CampusConnectAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserLogin> UsersLogin { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Fee> Fees { get; set; }
        public DbSet<TransactionRecord> Transactions { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowHistory> BorrowHistories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRegistration> EventsRegistrations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Faq> Faqs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // role -> user(one to  many )
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            //user ->logins(one to many)
            modelBuilder.Entity<UserLogin>()
                .HasOne(l => l.User)
                .WithMany(u => u.Logins)
                .HasForeignKey(l => l.UserId);
            //course ->subject (one to many)
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Subjects)
                .HasForeignKey(s => s.CourseId);
            //faculty user  ->course 
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Faculty)
                .WithMany()
                .HasForeignKey(c => c.FacultyId);
            //user -> enrollments (one to many)
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //course -> enrollments
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            //enrollment  --> grades
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Enrollment)
                .WithMany(e => e.Grades)
                .HasForeignKey(g => g.EnrollmentId);

            //Subject -->grades
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Subject)
                .WithMany()
                .HasForeignKey(g => g.SubjectId);
            // attendance -> user +subject
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Subject)
                .WithMany()
                .HasForeignKey(a => a.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            //fee -> Transactions

            modelBuilder.Entity<TransactionRecord>()
                .HasOne(t => t.Fee)
                .WithMany(f => f.Transactions)
                .HasForeignKey(t => t.FeeId);

            //fee ->user
            modelBuilder.Entity<Fee>()
                .HasOne(f=>f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId);

            //borrowhistory -> book & user
            modelBuilder.Entity<BorrowHistory>()
                .HasOne(b=>b.Book)
                .WithMany(bk=>bk.BorrowHistories)
                .HasForeignKey(b=>b.BookId);
            modelBuilder.Entity<BorrowHistory>()
                .HasOne(b=>b.User)
                .WithMany()
                .HasForeignKey(b=>b.UserId);
            // events -> creator
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Creator)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy);

            //eventregistration --> event +user
            modelBuilder.Entity<EventRegistration>()
             .HasOne(r => r.User)
             .WithMany(u => u.EventRegistrations)
             .HasForeignKey(r => r.UserId)
             .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EventRegistration>()
                .HasOne(r=>r.Event)
                .WithMany(e=>e.Registrations)
                .HasForeignKey(r=>r.EventId)
                .OnDelete(DeleteBehavior.Restrict);
         

            //contact -->user
            modelBuilder.Entity<Contact>()
                .HasOne(c=>c.User)
                .WithMany()
                .HasForeignKey(c=>c.UserId);
            //feedback  ->user
            modelBuilder.Entity<Feedback>()
                .HasOne(f=>f.User)
                .WithMany(u=>u.Feedbacks)
                .HasForeignKey(f=>f.UserId);




        }

    }
}
