namespace FullstackDevTS.Repositories;

public interface IRepository<T> where T : class //Models
{
  Task<IEnumerable<T>> GetAllAsync();
  Task<string> AddNewName(string newName);
}