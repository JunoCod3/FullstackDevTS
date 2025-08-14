using FullstackDevTS.Db;
using FullstackDevTS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullstackDevTS.Repositories.TestRepository;

public class TestRepositoryData : IRepository<TestModel>
{
    private readonly ApplicationDatabaseContext _context;
    
    public TestRepositoryData(ApplicationDatabaseContext context)
    {
        this._context = context;
    }
    
    public async Task<IEnumerable<TestModel>> GetAllAsync()
    {
        return await _context.TestModels.AsNoTracking().ToListAsync();
    }

    public async Task<string> AddNewName(string newName)
    {
        var testModel = new TestModel
        {
            Id = Guid.NewGuid(),
            Name = newName
        };
        
        await _context.TestModels.AddAsync(testModel);
        await _context.SaveChangesAsync();

        return "Success";
        
    }
}