using AutoMapper;
using BookWave.Entity.Dtos.BlogDtos;
using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.UOW;
using BookWave.Service.Abstract;
using BookWave.Service.Results;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookWave.Service.Concrete;

public class BlogService(IBlogRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IBlogService
{
    public async Task<ServiceResult> CreateAsync(CreateBlogDto request)
    {
        var blogEntity = mapper.Map<Blog>(request);
        await repository.AddAsync(blogEntity);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.Created);
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateBlogDto request)
    {
        var blogEntity = await repository.GetByIdAsync(id);
        if (blogEntity == null)
            return ServiceResult.Fail("Blog not found", HttpStatusCode.NotFound);

        blogEntity = mapper.Map(request, blogEntity);
        repository.Update(blogEntity);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.OK);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var blogEntity = await repository.GetByIdAsync(id);
        if (blogEntity == null)
            return ServiceResult.Fail("Blog not found", HttpStatusCode.NotFound);


        repository.Delete(blogEntity);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<BlogDto>>> GetAllListAsync()
    {
        var values = await repository.GetAll().ToListAsync();
        var valuesAsDto = mapper.Map<List<BlogDto>>(values);
        return ServiceResult<List<BlogDto>>.Success(valuesAsDto);
    }
}
