namespace BusinessLogic;

public sealed class ConcreteCustomerReport
{
  private readonly ICustomerReport _customerReport;
  public ConcreteCustomerReport(ICustomerReport customerReport)
  {
    _customerReport = customerReport;

  }
  public int GetAnnualProfitForCustomer(int customerId) =>
    _customerReport.GetAnnualProfitForCustomer(customerId);
}
