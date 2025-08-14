using FullstackDevTS.Commands.Response;
using FullstackDevTS.Models.Entities;

namespace FullstackDevTS.Services;

public interface ITestService
{
    Task<List<TestModel>> GetAllDataFromTestModel();
    Task<string> AddNewTestName(string name);
}   