using BookWave.Dto.GenreDtos;
using BookWave.Service.Result;

namespace BookWave.Service.Abstract;
public interface IGenreService
{
    Task<ServiceResult<List<GenreDto>>> GetAllListAsync();
    Task<ServiceResult<List<GenreDto>>> GetAllListPageAsync(int pageNumber, int pageSize);
    Task<ServiceResult<GenreDto>> GetByIdAsync(int id);
    Task<ServiceResult<int>> CreateAsync(CreateGenreDto request);
    Task<ServiceResult> UpdateAsync(int id, UpdateGenreDto request);
    Task<ServiceResult> DeleteAsync(int id);
}
