using CQRS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRS.API.DIs;

public static class ServiceRegistrations
{
    public static void ConfigureSqlContext(this IServiceCollection services)
    {
        string connectionString = Environment.GetEnvironmentVariable("SqlConnection__CleanArchitecture") ?? string.Empty;

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Database connection string is not set in environment variables.");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
    }
}