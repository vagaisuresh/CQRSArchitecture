using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<TodoItem> TodoItems { get; set; }
}