using FullstackDevTS.Commands.Dto;
using FullstackDevTS.Commands.Response;
using FullstackDevTS.Models.Entities;

namespace FullstackDevTS.Services;

public interface ICategoryService<T> where T : CategoryModel
{
    Task<ResponseDto<List<T?>>> GetAllCategoriesAsync();
    Task<ResponseDto<T?>> AddNewCategoryAsync(CategoryDataDto categoryDataDto);
}
