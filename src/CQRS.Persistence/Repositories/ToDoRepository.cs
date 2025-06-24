using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using CQRS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Persistence.Repositories;

public class ToDoRepository : RepositoryBase, IToDoRepository
{
    public ToDoRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<ToDoItem>> GetAllAsync()
    {
        return await _context.ToDoItems
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ToDoItem?> GetByIdAsync(int id)
    {
        return await _context.ToDoItems.FindAsync(id);
    }

    public async Task CreateAsync(ToDoItem toDoItem)
    {
        await _context.ToDoItems.AddAsync(toDoItem);
    }

    public void UpdateAsync(ToDoItem toDoItem)
    {
        _context.ToDoItems.Update(toDoItem);
    }

    public void DeleteAsync(ToDoItem toDoItem)
    {
        _context.ToDoItems.Remove(toDoItem);
    }
}