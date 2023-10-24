using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class IoCInstaller
{
  public static IServiceCollection AddBusinessLogic(this IServiceCollection services) =>
    services
      .AddTransient<ConcreteCustomerReport>()
      .AddTransient<ICustomerReport, CustomerReport>()
      .AddTransient<ICustomerReportRepository, CustomerReportRepository>();
}
