using BookWave.Entity.Dtos.PublisherDtos;
using BookWave.Service.Results;

namespace BookWave.Service.Abstract;
public interface IPublisherService
{
    Task<ServiceResult<List<PublisherDto>>> GetAllListAsync();
    Task<ServiceResult<List<PublisherDto>>> GetAllListPageAsync(int pageNumber, int pageSize);
    Task<ServiceResult<PublisherDto>> GetByIdAsync(int id);
    Task<ServiceResult> CreateAsync(CreatePublisherDto request);
    Task<ServiceResult> UpdateAsync(int id, UpdatePublisherDto request);
    Task<ServiceResult> DeleteAsync(int id);
}