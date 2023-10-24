# Business requirements testing framework
## An easy way to focus on what is most important and critical - business requirements

### Why do we test code when we have written code that meets business requirements?
**Start**:
* testing business requirements instead of specific code
* writing real test scenarios
* code refactoring with more confidence that afterwards applications will work as they did before refactoring

**Stop**:
* devoting your time and effort to test maintenance
* testing code instead of business requirements (we write code for business, not for the code itself)
* spending customers' money on test maintenance

### How to start testing business requirements
#### Install the required package

To install a Dzidek.Net.Testing module into project, Nuget Package Manager Console can be used:

```
Install-Package Dzidek.Net.Testing -ProjectName <ProjectName>
```

#### Create a Unit Test class
Create a test class that inherits from UnitTestBase<T>, where T is the interface or class you want to test.
```csharp
using Dzidek.Net.Testing;

public sealed class CustomerReportTests : UnitTestBase<ICustomerReport>
{
}
```

#### RegisterIoC method implementation
Register the class or interface under test in the abstract RegisterIoC method.
```csharp
protected override IServiceCollection RegisterServices(IServiceCollection services) =>
    services
      .AddBusinessLogic();
```

#### Replace the implementation of the outside world with a fake implementation
```csharp
protected override IServiceCollection SwapServices(IServiceCollection services) =>
    services
      .Swap<ICustomerReportRepository, FakeCustomerReportRepository>();
```

#### Write a test method
```csharp
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
```

#### Example test class
A working example can be found on github https://github.com/DzidekDotNet/Dzidek.Net.Testing/blob/main/BusinessLogic.Tests/CustomerReportTests.cs
```csharp
using Dzidek.Net.Testing;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Tests;

public sealed class CustomerReportTests : UnitTestBase<ICustomerReport>
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
```

### What is a Unit Test
A unit test is a type of software testing that focuses on verifying the correctness of individual components or units of a software application. In software development, a "unit" typically refers to the smallest testable part of a program, which could be a single function, method, or a small section of code. Unit tests are designed to ensure that these individual units or components work as expected and produce the correct output given a particular set of inputs.

### What does Unit Test mean in this approach?
A unit test is usually a small piece of code, but we will understand it as a single business function, and we will test this functionality independently of the outside world (databases, other services, APIs). The entire external world should be mocked up

### Changelog
- 1.0.0
    - Unit test implementation
- 1.0.1
    - Added readme to the nuget package

## Nuget packages
[Dzidek.Net.Testing](https://www.nuget.org/packages/Dzidek.Net.Testing)

## Authors
[@DzidekDotNet](https://www.github.com/DzidekDotNet)


## License
[MIT](https://github.com/DzidekDotNet/Dzidek.Net.Testing/blob/main/LICENSE)