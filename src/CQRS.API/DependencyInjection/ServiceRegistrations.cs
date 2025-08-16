using CQRS.Application.Features.Todo.Handlers;
using CQRS.Domain.Repositories;
using CQRS.Persistence.Context;
using CQRS.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CQRS.API.DependencyInjection;

public static class ServiceRegistrations
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<CreateTodoCommandHandler>();
    }

    public static void AddAppDbContext(this IServiceCollection services)
    {
        string connectionString = Environment.GetEnvironmentVariable("SqlConnection__CleanArchitecture") ?? string.Empty;

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Database connection string is not set in environment variables.");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
    }

    public static void AddAppCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }
}