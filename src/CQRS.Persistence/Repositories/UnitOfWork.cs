using CQRS.Domain.Repositories;
using CQRS.Persistence.Context;

namespace CQRS.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    private IToDoRepository _toDoRepository;

    public UnitOfWork(AppDbContext context,
        IToDoRepository toDoRepository)
    {
        _context = context;
        _toDoRepository = toDoRepository;
    }

    public IToDoRepository ToDoRepository => _toDoRepository;

    public async Task SaveAsync()
    {
        //await _context.SaveChangesAsync();
        await SaveAsync(CancellationToken.None);
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Dispose of the resources
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }
}