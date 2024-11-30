using AutoMapper;
using BookWave.Entity.Dtos.QuoteDtos;
using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.UOW;
using BookWave.Service.Abstract;
using BookWave.Service.Results;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookWave.Service.Concrete;
public class QuoteService(IQuoteRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IQuoteService
{
    public async Task<ServiceResult> CreateAsync(CreateQuoteDto request)
    {
        var valueAsDto = mapper.Map<Quote>(request);
        await repository.AddAsync(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.Created);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Quote not found", HttpStatusCode.NotFound);

        repository.Delete(value);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<QuoteDto>>> GetAllListAsync()
    {
        var values = await repository.GetAll().ToListAsync();
        var valuesAsDto = mapper.Map<List<QuoteDto>>(values);
        return ServiceResult<List<QuoteDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<List<QuoteDto>>> GetAllListPageAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
            return ServiceResult<List<QuoteDto>>.Fail("Page number and page size must be greater than zero.", HttpStatusCode.BadRequest);

        var values = await repository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        var valuesAsDto = mapper.Map<List<QuoteDto>>(values);
        return ServiceResult<List<QuoteDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<QuoteDto>> GetByIdAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);


        if (value is null)
            return ServiceResult<QuoteDto>.Fail("Quote not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<QuoteDto>(value);
        return ServiceResult<QuoteDto>.Success(valueAsDto);
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateQuoteDto request)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Quote not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<Quote>(request);
        valueAsDto.Id = id;
        repository.Update(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.OK);
    }
}
