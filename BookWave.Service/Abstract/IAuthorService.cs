using BookWave.Entity.Dtos.AuthorDtos;
using BookWave.Service.Results;

namespace BookWave.Service.Abstract;
public interface IAuthorService
{
    Task<ServiceResult<List<AuthorDto>>> GetAllListAsync();
    Task<ServiceResult<List<AuthorDto>>> GetAllListPageAsync(int pageNumber, int pageSize);
    Task<ServiceResult<GetAuthorWithBooksDto>> GetAuthorWithBooksAsync(int id);
    Task<ServiceResult<List<GetAuthorWithBooksDto>>> GetAuthorWithBooksAsync();
    Task<ServiceResult<List<GetAuthorWithQuotes>>> GetAuthorWithQuotesAsync();
    Task<ServiceResult<AuthorDto>> GetByIdAsync(int id);
    Task<ServiceResult> CreateAsync(CreateAuthorDto request);
    Task<ServiceResult> UpdateAsync(int id, UpdateAuthorDto request);
    Task<ServiceResult> DeleteAsync(int id);
}