using CQRS.Domain.Entities;

namespace CQRS.Domain.Repositories;

public interface IToDoRepository
{
    Task<List<ToDoItem>> GetAllAsync();
    Task CreateAsync(ToDoItem toDoItem);
}