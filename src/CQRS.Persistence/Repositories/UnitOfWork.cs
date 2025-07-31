using CQRS.Domain.Repositories;
using CQRS.Persistence.Context;

namespace CQRS.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    private ITodoRepository _todoRepository;

    public UnitOfWork(AppDbContext context,
        ITodoRepository todoRepository)
    {
        _context = context;
        _todoRepository = todoRepository;
    }

    public ITodoRepository TodoRepository => _todoRepository;

    public async Task SaveAsync()
    {
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