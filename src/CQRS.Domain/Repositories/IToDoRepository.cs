using CQRS.Domain.Entities;

namespace CQRS.Domain.Repositories;

public interface IToDoRepository
{
    Task<IEnumerable<ToDoItem>> GetAllAsync();
    Task<ToDoItem?> GetByIdAsync(int id);
    Task CreateAsync(ToDoItem toDoItem);
    void UpdateAsync(ToDoItem toDoItem);
    void DeleteAsync(ToDoItem toDoItem);
}