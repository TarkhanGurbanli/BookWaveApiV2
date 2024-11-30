using BookWave.Entity.Dtos.BookDtos;
using BookWave.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookWave.WebApi.Controllers;
public class BooksController(IBookService service) : CustomBaseController
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

    [HttpGet("details/{bookId:int}")]
    public async Task<IActionResult> GetBookWithDetails(int bookId)
       => CreateActionResult(await service.GetBookWithDetailsAsync(bookId));

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookDto request)
       => CreateActionResult(await service.CreateAsync(request));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateBookDto request)
       => CreateActionResult(await service.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
   => CreateActionResult(await service.DeleteAsync(id));
}