using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Application.DIs;

public static class ApplicationDependencies
{
    public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        return services;
    }
}