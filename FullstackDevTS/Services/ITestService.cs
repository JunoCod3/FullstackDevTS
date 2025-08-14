using FullstackDevTS.Commands.Response;
using FullstackDevTS.models;

namespace FullstackDevTS.Services;

public interface ITestService
{
    Task<List<TestModel>> GetAllDataFromTestModel();
    Task<string> AddNewTestName(string name);
}   