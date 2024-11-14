using BookWave.Dto.BookDtos;
using BookWave.Service.Result;

namespace BookWave.Service.Abstract;
public interface IBookService
{
    Task<ServiceResult<List<BookDto>>> GetAllListAsync();
    Task<ServiceResult<List<BookDto>>> GetAllListPageAsync(int pageNumber, int pageSize);
    Task<ServiceResult<BookDto>> GetByIdAsync(int id);
    Task<ServiceResult<GetBookWithDetails>> GetBookWithDetailsAsync(int bookId);
    Task<ServiceResult<int>> CreateAsync(CreateBookDto request);
    Task<ServiceResult> UpdateAsync(int id, UpdateBookDto request);
    Task<ServiceResult> DeleteAsync(int id);
}
