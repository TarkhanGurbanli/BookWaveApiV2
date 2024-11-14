using BookWave.Dto.PublisherDtos;
using BookWave.Service.Result;

namespace BookWave.Service.Abstract;
public interface IPublisherService
{
    Task<ServiceResult<List<PublisherDto>>> GetAllListAsync();
    Task<ServiceResult<List<PublisherDto>>> GetAllListPageAsync(int pageNumber, int pageSize);
    Task<ServiceResult<PublisherDto>> GetByIdAsync(int id);
    Task<ServiceResult<int>> CreateAsync(CreatePublisherDto request);
    Task<ServiceResult> UpdateAsync(int id, UpdatePublisherDto request);
    Task<ServiceResult> DeleteAsync(int id);
}
