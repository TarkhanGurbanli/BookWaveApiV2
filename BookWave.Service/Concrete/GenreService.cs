using AutoMapper;
using BookWave.Entity.Dtos.GenreDtos;
using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.UOW;
using BookWave.Service.Abstract;
using BookWave.Service.Results;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookWave.Service.Concrete;
public class GenreService(IGenreRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IGenreService
{
    public async Task<ServiceResult> CreateAsync(CreateGenreDto request)
    {
        var valueAsDto = mapper.Map<Category>(request);
        await repository.AddAsync(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.Created);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Genre not found", HttpStatusCode.NotFound);

        repository.Delete(value);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<GenreDto>>> GetAllListAsync()
    {
        var values = await repository.GetAll().ToListAsync();
        var valuesAsDto = mapper.Map<List<GenreDto>>(values);
        return ServiceResult<List<GenreDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<List<GenreDto>>> GetAllListPageAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
            return ServiceResult<List<GenreDto>>.Fail("Page number and page size must be greater than zero.", HttpStatusCode.BadRequest);

        var values = await repository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        var valuesAsDto = mapper.Map<List<GenreDto>>(values);
        return ServiceResult<List<GenreDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<GenreDto>> GetByIdAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);


        if (value is null)
            return ServiceResult<GenreDto>.Fail("Genre not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<GenreDto>(value);
        return ServiceResult<GenreDto>.Success(valueAsDto);
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateGenreDto request)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Genre not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<Category>(request);
        valueAsDto.Id = id;
        repository.Update(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.OK);
    }
}