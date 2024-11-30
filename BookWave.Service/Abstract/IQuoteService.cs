using BookWave.Entity.Dtos.QuoteDtos;
using BookWave.Service.Results;

namespace BookWave.Service.Abstract;
public interface IQuoteService
{
    Task<ServiceResult<List<QuoteDto>>> GetAllListAsync();
    Task<ServiceResult<List<QuoteDto>>> GetAllListPageAsync(int pageNumber, int pageSize);
    Task<ServiceResult<QuoteDto>> GetByIdAsync(int id);
    Task<ServiceResult> CreateAsync(CreateQuoteDto request);
    Task<ServiceResult> UpdateAsync(int id, UpdateQuoteDto request);
    Task<ServiceResult> DeleteAsync(int id);
}
