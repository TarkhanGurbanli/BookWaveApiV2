using BookWave.Entity.Dtos.BlogDtos;
using BookWave.Service.Results;

namespace BookWave.Service.Abstract;
public interface IBlogService
{
    Task<ServiceResult> CreateAsync(CreateBlogDto request);
    Task<ServiceResult> UpdateAsync(int id, UpdateBlogDto request);
    Task<ServiceResult> DeleteAsync(int id);
    Task<ServiceResult<List<BlogDto>>> GetAllListAsync();
}
