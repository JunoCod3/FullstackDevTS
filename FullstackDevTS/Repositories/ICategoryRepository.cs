using FullstackDevTS.Commands.Dto;
using FullstackDevTS.Models.Entities;

namespace FullstackDevTS.Repositories;

public interface ICategoryRepository<T> where T : class
{
    Task<IEnumerable<T?>> GetAllAsync();
    Task<CategoryModel> AddAsync(CategoryModel category);
    Task<bool> ExistsByNameAsync(string name);

}