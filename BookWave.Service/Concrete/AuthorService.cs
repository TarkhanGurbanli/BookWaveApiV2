using AutoMapper;
using BookWave.Entity.Dtos.AuthorDtos;
using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.UOW;
using BookWave.Service.Abstract;
using BookWave.Service.Results;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookWave.Service.Concrete;
public class AuthorService(IAuthorRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IAuthorService
{
    public async Task<ServiceResult> CreateAsync(CreateAuthorDto request)
    {
        var anyValue = await repository.Where(x => x.Name == request.Name).AnyAsync();

        if (anyValue)
            return ServiceResult.Fail("An author with the same name already exists.", HttpStatusCode.BadRequest);

        var valueAsDto = mapper.Map<Author>(request);
        await repository.AddAsync(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.Created);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Author not found", HttpStatusCode.NotFound);

        repository.Delete(value);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<AuthorDto>>> GetAllListAsync()
    {
        var values = await repository.GetAll().ToListAsync();
        var valuesAsDto = mapper.Map<List<AuthorDto>>(values);
        return ServiceResult<List<AuthorDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<List<AuthorDto>>> GetAllListPageAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
            return ServiceResult<List<AuthorDto>>.Fail("Page number and page size must be greater than zero.", HttpStatusCode.BadRequest);

        var values = await repository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        var valuesAsDto = mapper.Map<List<AuthorDto>>(values);
        return ServiceResult<List<AuthorDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<GetAuthorWithBooksDto>> GetAuthorWithBooksAsync(int id)
    {
        var value = await repository.GetAuthorWithBooksAsync(id);

        if (value is null)
            return ServiceResult<GetAuthorWithBooksDto>.Fail("Author not found", HttpStatusCode.NotFound);

        var authorWithBooksDto = value.Books.Select(book => new GetAuthorWithBooksDto(
            value.Id,
            value.Name,
            book.Id,
            book.Name,
            book.ImageUrl,
            book.Rating,
            book.Publisher?.Name ?? "Unknown"
        )).FirstOrDefault();

        if (authorWithBooksDto == null)
            return ServiceResult<GetAuthorWithBooksDto>.Fail("No books found for this author", HttpStatusCode.NotFound);

        return ServiceResult<GetAuthorWithBooksDto>.Success(authorWithBooksDto);
    }


    public async Task<ServiceResult<List<GetAuthorWithBooksDto>>> GetAuthorWithBooksAsync()
    {
        var authors = await repository.GetAuthorWithBooksAsync().ToListAsync();

        var authorWithBooksDto = authors
            .Where(author => author != null)
            .SelectMany(author => author!.Books.Select(book =>
                new GetAuthorWithBooksDto(
                    author.Id,
                    author.Name,
                    book.Id,
                    book.Name,
                    book.ImageUrl,
                    book.Rating,
                    book.Publisher?.Name ?? "Unknown"
                )
            )).ToList();

        return ServiceResult<List<GetAuthorWithBooksDto>>.Success(authorWithBooksDto);
    }

    public async Task<ServiceResult<List<GetAuthorWithQuotes>>> GetAuthorWithQuotesAsync()
    {
        var authorsWithQuotes = await repository.GetAuthorWithQuotesAsync().ToListAsync();

        var authorsWithQuotesDto = authorsWithQuotes
            .Where(author => author != null)
            .SelectMany(author => author!.Quotes.Select(quote =>
                new GetAuthorWithQuotes(
                    author.Id,
                    author.Name,
                    quote.Id,
                    quote.Text,
                    quote.Book?.Name ?? "Unknown"
                )
            )).ToList();

        return ServiceResult<List<GetAuthorWithQuotes>>.Success(authorsWithQuotesDto);
    }

    public async Task<ServiceResult<AuthorDto>> GetByIdAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);


        if (value is null)
            return ServiceResult<AuthorDto>.Fail("Author not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<AuthorDto>(value);
        return ServiceResult<AuthorDto>.Success(valueAsDto);
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateAuthorDto request)
    {
        var isExist = await repository.Where(x => x.Name == request.Name && x.Id != id).AnyAsync();
        var value = await repository.GetByIdAsync(id);

        if (isExist)
            return ServiceResult.Fail("An author with the same name already exists.", HttpStatusCode.BadRequest);

        if (value is null)
            return ServiceResult.Fail("Author not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<Author>(request);
        valueAsDto.Id = id;
        repository.Update(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.OK);
    }
}
