namespace CQRS.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IToDoRepository ToDoRepository { get; }

    /// <summary>
    /// SaveAsync is used to commit changes to the database. It wraps the call to SaveChangesAsync on the database context.
    /// </summary>
    /// <returns></returns>
    Task SaveAsync();

    Task SaveAsync(CancellationToken cancellationToken);
}