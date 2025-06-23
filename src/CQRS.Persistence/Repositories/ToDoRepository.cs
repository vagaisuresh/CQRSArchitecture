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

    public async Task<List<ToDoItem>> GetAllAsync()
    {
        return await _context.ToDoItems
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task CreateAsync(ToDoItem toDoItem)
    {
        await _context.ToDoItems.AddAsync(toDoItem);
        await _context.SaveChangesAsync();
    }
}