using BookWave.Entity.Dtos.AuthorDtos;
using BookWave.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookWave.WebApi.Controllers;
public class AuthorsController(IAuthorService service) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => CreateActionResult(await service.GetAllListAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
       => CreateActionResult(await service.GetByIdAsync(id));

    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<IActionResult> GetAllPaged(int pageNumber, int pageSize)
       => CreateActionResult(await service.GetAllListPageAsync(pageNumber, pageSize));

    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorDto request)
       => CreateActionResult(await service.CreateAsync(request));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateAuthorDto request)
       => CreateActionResult(await service.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
        => CreateActionResult(await service.DeleteAsync(id));

    [HttpGet("with-books/{id:int}")]
    public async Task<IActionResult> GetAuthorWithBooks(int id)
        => CreateActionResult(await service.GetAuthorWithBooksAsync(id));

    [HttpGet("with-books")]
    public async Task<IActionResult> GetAuthorsWithBooks()
        => CreateActionResult(await service.GetAuthorWithBooksAsync());

    [HttpGet("with-quotes")]
    public async Task<IActionResult> GetAuthorsWithQuotes()
        => CreateActionResult(await service.GetAuthorWithQuotesAsync());
}