using FullstackDevTS.Commands.Handler.QueryHandler;
using FullstackDevTS.Commands.Response;
using FullstackDevTS.Models.Entities;
using FullstackDevTS.Services;
using MediatR;

namespace FullstackDevTS.Commands.Handler;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ResponseDto<List<CategoryModel?>>>
{
    private readonly ICategoryService<CategoryModel>  _categoryService;

    public GetAllCategoriesQueryHandler(ICategoryService<CategoryModel> categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<ResponseDto<List<CategoryModel?>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
         return await _categoryService.GetAllCategoriesAsync();
    }
    
}