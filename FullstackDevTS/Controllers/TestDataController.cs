using FullstackDevTS.Commands.Dto;
using FullstackDevTS.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace FullstackDevTS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestDataController : ControllerBase 
{
    
    private readonly ITestService _service;
    private readonly IMediator _mediator;
    
    public TestDataController(ITestService service, IMediator mediator)
    {
        _service = service;
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("get-all-test-data")]
    public async Task<IActionResult> GetAllData()
    {
        var data = await _service.GetAllDataFromTestModel();
        
        return Ok(data);
        
    }

    [HttpPost]
    [Route("add-test-name")]
    public async Task<IActionResult> AddNewName([FromBody] TestDataDto dto)
    {
        var result = await _mediator.Send(new TestDataDto {  Name = dto.Name });
        
        return Ok(result);
        
    }
    
}