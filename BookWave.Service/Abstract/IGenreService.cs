using BookWave.Entity.Dtos.GenreDtos;
using BookWave.Service.Results;

namespace BookWave.Service.Abstract;
public interface IGenreService
{
    Task<ServiceResult<List<GenreDto>>> GetAllListAsync();
    Task<ServiceResult<List<GenreDto>>> GetAllListPageAsync(int pageNumber, int pageSize);
    Task<ServiceResult<GenreDto>> GetByIdAsync(int id);
    Task<ServiceResult> CreateAsync(CreateGenreDto request);
    Task<ServiceResult> UpdateAsync(int id, UpdateGenreDto request);
    Task<ServiceResult> DeleteAsync(int id);
}