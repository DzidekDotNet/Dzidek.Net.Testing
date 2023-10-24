namespace BusinessLogic;

public interface ICustomerReport
{
  public int GetAnnualProfitForCustomer(int customerId);
}

internal sealed class CustomerReport : ICustomerReport
{
  private readonly ICustomerReportRepository _customerReportRepository;
  public CustomerReport(ICustomerReportRepository customerReportRepository)
  {
    _customerReportRepository = customerReportRepository;

  }
  public int GetAnnualProfitForCustomer(int customerId) =>
    _customerReportRepository.GetLastYearProfitForCustomer(customerId).Sum(x=> x.Value);
}

internal interface ICustomerReportRepository
{
  public IEnumerable<(int Month, int Value)> GetLastYearProfitForCustomer(int customerId);
}

internal sealed class CustomerReportRepository: ICustomerReportRepository
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
        new (1, customerId),
        new (2, customerId),
      }
    };
}