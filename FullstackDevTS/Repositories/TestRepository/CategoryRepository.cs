using System.Collections.Immutable;
using System.Data.SqlTypes;
using FullstackDevTS.Commands.Dto;
using FullstackDevTS.Db;
using FullstackDevTS.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

namespace FullstackDevTS.Repositories.TestRepository;

public class CategoryRepository : ICategoryRepository<CategoryModel>
{
    private readonly ApplicationDatabaseContext _context;
    
    public CategoryRepository(ApplicationDatabaseContext context)
    {
        this._context  = context;
    }
    
    public async Task<IEnumerable<CategoryModel?>> GetAllAsync()
    {
        return await _context.CategoryModels.ToListAsync();
    }

    public async Task<CategoryModel> AddAsync(CategoryModel category)
    {
        await _context.CategoryModels.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }
    
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.CategoryModels
            .AsQueryable()
            .AnyAsync(c => c.Name.ToLower() == name.ToLower());
    }

}