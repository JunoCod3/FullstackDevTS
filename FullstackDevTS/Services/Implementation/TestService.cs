using FullstackDevTS.Models.Entities;
using FullstackDevTS.Repositories;

namespace FullstackDevTS.Services.Implementation;

public class TestService : ITestService
{
    private readonly IRepository<TestModel> _repository;
    
    public TestService(IRepository<TestModel> repository)
    {
        this._repository = repository;
    }
    
    public async Task<List<TestModel>> GetAllDataFromTestModel()
    {
        return (await this._repository.GetAllAsync()).ToList();
    }

    public async Task<string> AddNewTestName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return "Name is empty";
        }
        
        return await this._repository.AddNewName(name);
    }
}