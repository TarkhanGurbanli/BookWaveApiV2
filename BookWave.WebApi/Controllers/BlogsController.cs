using BookWave.Entity.Dtos.BlogDtos;
using BookWave.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookWave.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogsController(IBlogService service) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await service.GetAllListAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBlogDto request) 
        => CreateActionResult(await service.CreateAsync(request));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBlogDto request) 
        => CreateActionResult(await service.UpdateAsync(id,request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) 
        => CreateActionResult(await service.DeleteAsync(id));
}
