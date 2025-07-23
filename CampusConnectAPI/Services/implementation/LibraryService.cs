using CampusConnectAPI.DTOs.Library;
using CampusConnectAPI.Repositories.Interfaces;
using CampusConnectAPI.Services.Interfaces;

namespace CampusConnectAPI.Services.implementation
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _Repository;
        public LibraryService(ILibraryRepository repository)
        {
            _Repository = repository;
        }

        public async Task<List<BookResponseDto>> GetAvailableBooksAsync()=>
            await _Repository.GetAvailableBooksAsync();

        public async Task<BorrowHistoryDto> BorrowBookAsync(BorrowRequestDto dto) =>
            await _Repository.BorrowBookAsync(dto);

       public async Task<List<BorrowHistoryDto>> GetBorrowHistoryAsync(Guid userId)=>
            await _Repository.GetBorrowHistoryAsync(userId);
    }
}
