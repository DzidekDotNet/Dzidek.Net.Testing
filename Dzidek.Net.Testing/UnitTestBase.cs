using Microsoft.Extensions.DependencyInjection;

namespace Dzidek.Net.Testing;

public abstract class UnitTestBase<T> : TestBase<T> where T : notnull
{
  protected abstract IServiceCollection RegisterServices(IServiceCollection services);
  protected abstract IServiceCollection SwapServices(IServiceCollection services);

  protected override IServiceCollection RegisterIoC(IServiceCollection services) =>
    SwapServices(RegisterServices(services));

}
