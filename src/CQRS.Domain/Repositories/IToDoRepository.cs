using CQRS.Domain.Entities;

namespace CQRS.Domain.Repositories;

public interface ITodoRepository
{
    Task<IEnumerable<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(int id);
    Task CreateAsync(TodoItem todoItem);
    void Update(TodoItem todoItem);
    void Delete(TodoItem todoItem);
}