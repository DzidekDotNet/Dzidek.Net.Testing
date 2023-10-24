namespace BusinessLogic.Tests;

// ReSharper disable once ClassNeverInstantiated.Global
internal sealed class FakeCustomerReportRepository: ICustomerReportRepository
{
  public IEnumerable<(int Month, int Value)> GetLastYearProfitForCustomer(int customerId) =>
    customerId switch
    {
      1 => new List<(int Month, int Value)>()
      {
        new (1, 2),
        new (2, 8),
      },
      2 => new List<(int Month, int Value)>()
      {
        new (1, 2),
        new (2, 8),
        new (3, 2),
      },
      _ => new List<(int Month, int Value)>()
      {
        new (1, customerId*customerId),
      }
    };
}
