using CQRS.Domain.Repositories;
using CQRS.Persistence.Repositories;

namespace CQRS.API.DIs;

public static class DependencyBindings
{
    public static void ConfigureDependencyBindings(this IServiceCollection services)
    {
        services.AddScoped<IToDoRepository, ToDoRepository>();
    }
}