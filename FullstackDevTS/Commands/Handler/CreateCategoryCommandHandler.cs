using FullstackDevTS.Commands.Dto;
using FullstackDevTS.Commands.Response;
using FullstackDevTS.Models.Entities;
using FullstackDevTS.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FullstackDevTS.Commands.Handler;

public class CreateCategoryCommandHandler : IRequestHandler<CategoryDataDto, ResponseDto<CategoryModel?>>
{
    
    private readonly ICategoryService<CategoryModel> _service;

    public CreateCategoryCommandHandler(ICategoryService<CategoryModel> service)
    {
        _service = service;
    }
    
    public async Task<ResponseDto<CategoryModel?>> Handle(CategoryDataDto request, CancellationToken cancellationToken)
    {
        return await _service.AddNewCategoryAsync(request);
    }   
    
}