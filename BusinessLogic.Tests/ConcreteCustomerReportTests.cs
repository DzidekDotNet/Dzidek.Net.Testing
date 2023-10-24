using Dzidek.Net.Testing;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Tests;

public sealed class ConcreteCustomerReportTests : UnitTestBase<ConcreteCustomerReport>
{
  protected override IServiceCollection RegisterServices(IServiceCollection services) =>
    services
      .AddBusinessLogic();

  protected override IServiceCollection SwapServices(IServiceCollection services) =>
    services
      .Swap<ICustomerReportRepository, FakeCustomerReportRepository>();

  [Theory]
  [InlineData(1, 10)]
  [InlineData(2, 12)]
  [InlineData(3, 9)]
  [InlineData(4, 16)]
  internal void GetAnnualProfitForCustomer_ForEachCustomer_ShouldGenerateProperData(int customerId, int expectedAnnualProfit)
  {
    var result = Testee.GetAnnualProfitForCustomer(customerId);
    result.Should().Be(expectedAnnualProfit);
  }
}
