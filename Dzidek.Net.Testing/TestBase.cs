using Microsoft.Extensions.DependencyInjection;

namespace Dzidek.Net.Testing;

public abstract class TestBase<T> where T : notnull
{
  private IServiceProvider ServiceProvider { get; }

  protected T Testee { get; }
  protected abstract IServiceCollection RegisterIoC(IServiceCollection services);
  protected TestBase()
  {
    var serviceCollection = new ServiceCollection();
    // ReSharper disable once VirtualMemberCallInConstructor
    RegisterIoC(serviceCollection);

    ServiceProvider = serviceCollection.BuildServiceProvider();

    Testee = ServiceProvider.GetRequiredService<T>();
  }
}
