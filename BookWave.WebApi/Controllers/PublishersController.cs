using BookWave.Entity.Dtos.PublisherDtos;
using BookWave.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BookWave.WebApi.Controllers;
public class PublishersController(IPublisherService service) : CustomBaseController
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
    public async Task<IActionResult> Create(CreatePublisherDto request)
       => CreateActionResult(await service.CreateAsync(request));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdatePublisherDto request)
       => CreateActionResult(await service.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
   => CreateActionResult(await service.DeleteAsync(id));
}