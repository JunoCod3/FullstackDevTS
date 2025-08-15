using FullstackDevTS.Commands.Dto;
using FullstackDevTS.Commands.Response;
using FullstackDevTS.Models.Entities;
using FullstackDevTS.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FullstackDevTS.Services.Implementation;

public class CategoryService : ICategoryService<CategoryModel>
{
    private readonly ICategoryRepository<CategoryModel> _categoryRepository;
    
    public CategoryService(ICategoryRepository<CategoryModel> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<ResponseDto<List<CategoryModel?>>> GetAllCategoriesAsync()
    {
        var categories = (await _categoryRepository.GetAllAsync()).ToList();

        var response = new ResponseDto<List<CategoryModel?>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = categories
        };

        return response;
        
    }

    public async Task<ResponseDto<CategoryModel?>> AddNewCategoryAsync(CategoryDataDto dto)
    {
        var response = new ResponseDto<CategoryModel?>();
        
        var isCategoryNameUsed = await _categoryRepository.ExistsByNameAsync(dto.Name);
        
        if (isCategoryNameUsed) throw new Exception("Category name already exists");
        
        var category = new CategoryModel
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            CreatedDate = DateTime.UtcNow
        };

        var result = await _categoryRepository.AddAsync(category);

        response.StatusCode = 201;
        response.Message = "Success";
        response.Data = result;
        
        return response;
        
    }



}