using BookWave.Dto.BookGenreDtos;
using BookWave.Service.Result;

namespace BookWave.Service.Abstract;
public interface IBookGenreService
{
    Task<ServiceResult<List<BookGenreDto>>> GetAllListAsync();
    Task<ServiceResult<List<BookGenreDto>>> GetAllListPageAsync(int pageNumber, int pageSize);
    Task<ServiceResult<BookGenreDto>> GetByIdAsync(int id);
    Task<ServiceResult<int>> CreateAsync(CreateBookGenreDto request);
    Task<ServiceResult> UpdateAsync(int id, UpdateBookGenreDto request);
    Task<ServiceResult> DeleteAsync(int id);
}
