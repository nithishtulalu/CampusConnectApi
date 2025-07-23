using CampusConnectAPI.DTOs.Library;
using CampusConnectAPI.Models;
using CampusConnectAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectAPI.Repositories.implementation
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly ApplicationDbContext _context;
        public LibraryRepository(ApplicationDbContext applicationDb)
        {
            _context = applicationDb;
        }

        public async Task<List<BookResponseDto>> GetAvailableBooksAsync()
        {
            try
            {
                var books= await _context.Books
                    .Where(b=>b.AvailableCopies >0)
                    .ToListAsync();

                return books.Select(b=>new BookResponseDto
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Auther=b.Author,
                    ISBN=b.ISBN,
                    AvailableCopies=b.AvailableCopies,
                }).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<BorrowHistoryDto> BorrowBookAsync(BorrowRequestDto dto)
        {
            try
            {
                var  user =await _context.Users.Include(u=>u.RoleId)
                    .FirstOrDefaultAsync(u=>u.UserId==dto.UserId);

                if (user == null || user.Role.RoleName != "Student")
                    return null;
                var book= await _context.Books.FindAsync(dto.BookId);
                if (book == null || book.AvailableCopies <= 0)
                    return null;

                var borrow = new BorrowHistory
                {
                    BorrowId = Guid.NewGuid(),
                    UserId = dto.UserId,
                    BookId = dto.BookId,
                    BorrowDate = DateTime.UtcNow
                };
                book.AvailableCopies -=1;
                _context.BorrowHistories.Add(borrow);
                _context.Books.Update(book);
                 await _context.SaveChangesAsync();

                return new BorrowHistoryDto
                {
                    BorrowId = borrow.BorrowId,
                    Title = book.Title,
                    BorrowDate = borrow.BorrowDate,
                    ReturnDate = borrow.ReturnDate,
                };


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<BorrowHistoryDto>> GetBorrowHistoryAsync(Guid userId)
        {
            try
            {
                var history= await _context.BorrowHistories
                    .Include(b=>b.BookId)
                    .Where(b=>b.UserId == userId)
                    .OrderByDescending(b=>b.BorrowDate)
                    .ToListAsync();

                return history.Select(b=>new BorrowHistoryDto
                {
                    BorrowId = b.BorrowId,
                    Title=b.Book?.Title ??"Unknow ",
                    BorrowDate = b.BorrowDate,
                    ReturnDate = b.ReturnDate
                }).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
