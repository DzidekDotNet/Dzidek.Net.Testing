using Microsoft.Extensions.DependencyInjection;

namespace Dzidek.Net.Testing;

public static class ServiceCollectionSwapExtensions
{
    public static IServiceCollection Swap<TService, TImplementation>(this IServiceCollection serviceCollection, ServiceLifetime lifeTime = ServiceLifetime.Transient) where TImplementation : class, TService
    {
        serviceCollection
            .RemoveRegistration<TService>(lifeTime)
            .Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), lifeTime));
        return serviceCollection;
    }

    public static IServiceCollection Swap<TService, TImplementation>(this IServiceCollection serviceCollection, Func<IServiceProvider, TImplementation> implementationFactory, ServiceLifetime lifeTime = ServiceLifetime.Transient)
        where TImplementation : class, TService
    {
        serviceCollection
            .RemoveRegistration<TService>(lifeTime)
            .Add(new ServiceDescriptor(typeof(TService), implementationFactory, lifeTime));
        return serviceCollection;
    }
    private static IServiceCollection RemoveRegistration<TService>(this IServiceCollection serviceCollection, ServiceLifetime lifeTime)
    {
        var services = serviceCollection.Where(x => x.ServiceType == typeof(TService) && x.Lifetime == lifeTime).ToList();
        if (services.Any())
        {
            foreach (var service in services)
            {
                serviceCollection.Remove(service);
            }
        }
        return serviceCollection;
    }
}
