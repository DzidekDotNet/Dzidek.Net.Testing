using Microsoft.Extensions.DependencyInjection;

namespace Dzidek.Net.Testing;

public abstract class IntegrationTestBase<T> : TestBase<T> where T : notnull
{
  protected abstract IServiceCollection RegisterServices(IServiceCollection services);
  protected virtual IServiceCollection SwapServices(IServiceCollection services) => services;

  protected override IServiceCollection RegisterIoC(IServiceCollection services) =>
    SwapServices(RegisterServices(services));

}
