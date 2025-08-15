using FullstackDevTS.Commands.Dto;
using FullstackDevTS.Commands.Handler;
using FullstackDevTS.Commands.Handler.QueryHandler;
using FullstackDevTS.Models.Entities;
using FullstackDevTS.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullstackDevTS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    
    private readonly IMediator _mediator;
    private ICategoryService<CategoryModel> _service;

    public CategoryController(IMediator mediator, ICategoryService<CategoryModel> service)
    {
        _mediator = mediator;
        _service = service;
    }

    [HttpGet]
    [Route("get-all-categories")]
    public async Task<IActionResult> FetchAllCategoriesAsync()
    {
        //using Repository 
        // var repoResult = await _service.GetAllCategoriesAsync();
        
        //using MediaTR
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        
        if (result.StatusCode == 200)
            return Ok(result);
        else
            return BadRequest(result);
    }
    
    [HttpPost]
    [Route("create-category")]
    public async Task<IActionResult> InsertCategoryAsync([FromBody] CategoryDataDto category)
    {
        try
        {
            //using Repository
            // var repoResult = await _service.AddNewCategoryAsync(category);
        
            //using MediaTR
            var result = await _mediator.Send(category);

            if (result.StatusCode == 201)
                return Created("",result);
            else
                return BadRequest(result);
        }
        catch (Exception e)
        {
            return StatusCode(400, e.Message);
        }
        
    }
    
    
}