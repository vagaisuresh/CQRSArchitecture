using CQRS.Domain.Entities;
using CQRS.Domain.Repositories;
using CQRS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Persistence.Repositories;

public class TodoRepository : RepositoryBase, ITodoRepository
{
    public TodoRepository(AppDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync()
    {
        return await _context.TodoItems
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(int id)
    {
        return await _context.TodoItems.FindAsync(id);
    }

    public async Task CreateAsync(TodoItem todoItem)
    {
        await _context.TodoItems.AddAsync(todoItem);
    }

    public void Update(TodoItem todoItem)
    {
        _context.TodoItems.Update(todoItem);
    }

    public void Delete(TodoItem todoItem)
    {
        _context.TodoItems.Remove(todoItem);
    }
}