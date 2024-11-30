using AutoMapper;
using BookWave.Entity.Dtos.BookGenreDtos;
using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.UOW;
using BookWave.Service.Abstract;
using BookWave.Service.Results;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookWave.Service.Concrete;
public class BookGenreService(IBookGenreRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IBookGenreService
{
    public async Task<ServiceResult> CreateAsync(CreateBookGenreDto request)
    {
        var valueAsDto = mapper.Map<BookGenre>(request);
        await repository.AddAsync(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.Created);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Book Genre not found", HttpStatusCode.NotFound);

        repository.Delete(value);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<BookGenreDto>>> GetAllListAsync()
    {
        var values = await repository.GetAll().ToListAsync();
        var valuesAsDto = mapper.Map<List<BookGenreDto>>(values);
        return ServiceResult<List<BookGenreDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<List<BookGenreDto>>> GetAllListPageAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
            return ServiceResult<List<BookGenreDto>>.Fail("Page number and page size must be greater than zero.", HttpStatusCode.BadRequest);

        var values = await repository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        var valuesAsDto = mapper.Map<List<BookGenreDto>>(values);
        return ServiceResult<List<BookGenreDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<BookGenreDto>> GetByIdAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);


        if (value is null)
            return ServiceResult<BookGenreDto>.Fail("Book Genre not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<BookGenreDto>(value);
        return ServiceResult<BookGenreDto>.Success(valueAsDto);
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateBookGenreDto request)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Book Genre not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<BookGenre>(request);
        valueAsDto.Id = id;
        repository.Update(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.OK);
    }
}