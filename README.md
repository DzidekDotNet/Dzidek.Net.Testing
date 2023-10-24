<a name="readme-top"></a>
<h1 style="text-align: center;">Business requirements testing framework</h1>
<h3 style="text-align: center;">An easy way to focus on what is most important and critical - business requirements</h3>
<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#why-do-we-test-code-when-we-have-written-code-that-meets-business-requirements">Why do we test code when we have written code that meets business requirements?</a></li>
    <li>
        <a href="#how-to-start-testing-business-requirements">How to start testing business requirements</a>
        <ol>
            <li><a href="#install-the-required-package">Install the required package</a></li>
            <li><a href="#create-a-unit-test-class">Create a Unit Test class</a></li>
            <li><a href="#registerioc-method-implementation">RegisterIoC method implementation</a></li>
            <li><a href="#replace-the-implementation-of-the-outside-world-with-a-fake-implementation">Replace the implementation of the outside world with a fake implementation</a></li>
            <li><a href="#write-a-test-method">Write a test method</a></li>
            <li><a href="#example-test-class">Example test class</a></li>
        </ol>
    </li>
    <li><a href="#what-is-unit-test">What is a Unit Test</a></li>
    <li><a href="#what-does-unit-test-mean-in-this-approach">What does Unit Test mean in this approach?</a></li>
    <li><a href="#changelog">Changelog</a></li>
    <li><a href="#nugetpackages">Nuget packages</a></li>
    <li><a href="#authors">Authors</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>

### Why do we test code when we have written code that meets business requirements? 
**Start**:
* testing business requirements instead of specific code
* writing real test scenarios
* code refactoring with more confidence that afterwards applications will work as they did before refactoring

**Stop**:
* devoting your time and effort to test maintenance
* testing code instead of business requirements (we write code for business, not for the code itself)
* spending customers' money on test maintenance 
<p style="text-align: right;">(<a href="#readme-top">back to top</a>)</p>

### How to start testing business requirements
#### Install the required package

To install a Dzidek.Net.Testing module into project, Nuget Package Manager Console can be used:

```
Install-Package Dzidek.Net.Testing -ProjectName <ProjectName>
```
<p style="text-align: right;">(<a href="#readme-top">back to top</a>)</p>

#### Create a Unit Test class
Create a test class that inherits from UnitTestBase<T>, where T is the interface or class you want to test.
```csharp
using Dzidek.Net.Testing;

public sealed class CustomerReportTests : UnitTestBase<ICustomerReport>
{
}
```
<p style="text-align: right;">(<a href="#readme-top">back to top</a>)</p>

#### RegisterIoC method implementation
Register the class or interface under test in the abstract RegisterIoC method.
```csharp
protected override IServiceCollection RegisterServices(IServiceCollection services) =>
    services
      .AddBusinessLogic();
```
<p style="text-align: right;">(<a href="#readme-top">back to top</a>)</p>

#### Replace the implementation of the outside world with a fake implementation
```csharp
protected override IServiceCollection SwapServices(IServiceCollection services) =>
    services
      .Swap<ICustomerReportRepository, FakeCustomerReportRepository>();
```
<p style="text-align: right;">(<a href="#readme-top">back to top</a>)</p>

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
<p style="text-align: right;">(<a href="#readme-top">back to top</a>)</p>

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
<p style="text-align: right;">(<a href="#readme-top">back to top</a>)</p>

### What is a Unit Test
A unit test is a type of software testing that focuses on verifying the correctness of individual components or units of a software application. In software development, a "unit" typically refers to the smallest testable part of a program, which could be a single function, method, or a small section of code. Unit tests are designed to ensure that these individual units or components work as expected and produce the correct output given a particular set of inputs.
<p style="text-align: right;">(<a href="#readme-top">back to top</a>)</p>

### What does Unit Test mean in this approach?
A unit test is usually a small piece of code, but we will understand it as a single business function, and we will test this functionality independently of the outside world (databases, other services, APIs). The entire external world should be mocked up 
<p style="text-align: right;">(<a href="#readme-top">back to top</a>)</p>

### Changelog
- 1.0.0
    - Unit test implementation

## Nuget packages
[Dzidek.Net.Testing](https://www.nuget.org/packages/Dzidek.Net.Testing)

## Authors
[@DzidekDotNet](https://www.github.com/DzidekDotNet)


## License
[MIT](https://github.com/DzidekDotNet/Dzidek.Net.Testing/blob/main/LICENSE)