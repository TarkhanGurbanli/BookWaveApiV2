using AutoMapper;
using BookWave.Entity.Dtos.BookDtos;
using BookWave.Entity.Dtos.CommentDtos;
using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.UOW;
using BookWave.Service.Abstract;
using BookWave.Service.Results;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookWave.Service.Concrete;
public class BookService(IBookRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IBookService
{
    public async Task<ServiceResult> CreateAsync(CreateBookDto request)
    {
        var valueAsDto = mapper.Map<Book>(request);
        await repository.AddAsync(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.Created);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Book not found", HttpStatusCode.NotFound);

        repository.Delete(value);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult<List<BookDto>>> GetAllListAsync()
    {
        var values = await repository.GetAll().ToListAsync();
        var valuesAsDto = mapper.Map<List<BookDto>>(values);
        return ServiceResult<List<BookDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<List<BookDto>>> GetAllListPageAsync(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
            return ServiceResult<List<BookDto>>.Fail("Page number and page size must be greater than zero.", HttpStatusCode.BadRequest);

        var values = await repository.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        var valuesAsDto = mapper.Map<List<BookDto>>(values);
        return ServiceResult<List<BookDto>>.Success(valuesAsDto);
    }

    public async Task<ServiceResult<GetBookWithDetails>> GetBookWithDetailsAsync(int bookId)
    {
        var book = await repository.GetBookWithDetails(bookId);

        if (book is null)
            return ServiceResult<GetBookWithDetails>.Fail("Book not found", HttpStatusCode.NotFound);

        var bookWithDetailsDto = new GetBookWithDetails(
            Id: book.Id,
            Name: book.Name,
            Description: book.Description,
            ImageUrl: book.ImageUrl,
            Rating: book.Rating,
            AuthorName: book.Author.Name,
            PublisherName: book.Publisher.Name,
            BookGenreNames: book.BookCategories.Select(bg => bg.Category.Name).ToList(),
            Comments: book.Comments.Select(c => new CommentDto(
                Id: c.Id,
                Text: c.Text,
                UserName: c.User.Username
            )).ToList()
        );

        return ServiceResult<GetBookWithDetails>.Success(bookWithDetailsDto);
    }

    public async Task<ServiceResult<BookDto>> GetByIdAsync(int id)
    {
        var value = await repository.GetByIdAsync(id);


        if (value is null)
            return ServiceResult<BookDto>.Fail("Book not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<BookDto>(value);
        return ServiceResult<BookDto>.Success(valueAsDto);
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateBookDto request)
    {
        var value = await repository.GetByIdAsync(id);

        if (value is null)
            return ServiceResult.Fail("Book not found", HttpStatusCode.NotFound);

        var valueAsDto = mapper.Map<Book>(request);
        valueAsDto.Id = id;
        repository.Update(valueAsDto);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.OK);
    }
}