using AutoMapper;
using BookWave.Dto.PublisherDtos;
using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.UOW;
using BookWave.Service.Abstract;
using BookWave.Service.Result;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookWave.Service.Concrete;
public class PublisherService(IPubLisherRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IPublisherService
{
    public async Task<ServiceResult<int>> CreateAsync(CreatePublisherDto request)
    {
        var anyValue = await repository.Where(x => x.Name == request.Name).AnyAsync();

        if (anyValue)
            return ServiceResult<int>.Fail("An publisher with the same name already exists.", HttpStatusCode.BadRequest);

        var valueAsDto = mapper.Map<Publisher>(request);
        await repository.AddAsync(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<int>.SuccessAsCreated(valueAsDto.Id, $"api/publishers/{valueAsDto}");
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Publisher not found", HttpStatusCode.NotFound);

        repository.Delete(value);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<PublisherDto>>> GetAllListAsync()
    {
        var values = await repository.GetAll().ToListAsync();
        var valuesAsDto = mapper.Map<List<PublisherDto>>(values);
        return ServiceResult<List<PublisherDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<List<PublisherDto>>> GetAllListPageAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
            return ServiceResult<List<PublisherDto>>.Fail("Page number and page size must be greater than zero.", HttpStatusCode.BadRequest);

        var values = await repository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        var valuesAsDto = mapper.Map<List<PublisherDto>>(values);
        return ServiceResult<List<PublisherDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<PublisherDto>> GetByIdAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);


        if (value is null)
            return ServiceResult<PublisherDto>.Fail("Publisher not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<PublisherDto>(value);
        return ServiceResult<PublisherDto>.Success(valueAsDto);
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdatePublisherDto request)
    {
        var isExist = await repository.Where(x => x.Name == request.Name && x.Id != id).AnyAsync();
        var value = await repository.GetByIdAsync(id);

        if (isExist)
            return ServiceResult.Fail("An publisher with the same name already exists.", HttpStatusCode.BadRequest);

        if (value is null)
            return ServiceResult.Fail("Publisher not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<Publisher>(request);
        valueAsDto.Id = id;
        repository.Update(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.OK);
    }
}
