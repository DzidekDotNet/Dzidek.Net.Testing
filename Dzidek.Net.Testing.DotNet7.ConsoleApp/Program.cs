using BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services
  .AddBusinessLogic();
using IHost host = builder.Build();

var customerReport = host.Services.GetRequiredService<ICustomerReport>();

Console.WriteLine(customerReport.GetAnnualProfitForCustomer(1));
