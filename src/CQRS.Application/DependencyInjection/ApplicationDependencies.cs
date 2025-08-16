using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Application.DependencyInjection;

public static class ApplicationDependencies
{
    public static IServiceCollection AddAppMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        return services;
    }
}