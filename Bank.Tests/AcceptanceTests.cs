using System.Text;
using Bank.Tests.Mocks;

namespace Bank.Tests;

public class AcceptanceTests
{
    [Fact(Skip = "Acceptance test to be run after whole implementation is done")]
    public void FirstAcceptanceTest()
    {
        // Arrange
        var timeService = new MockTimeProvider();
        var printer = new MockPrinter();
        var account = new AccountService(timeService, printer);

        timeService.SetTime(new DateTime(2012, 1, 10));
        account.Deposit(1000);

        timeService.SetTime(new DateTime(2012, 1, 13));
        account.Deposit(2000);

        timeService.SetTime(new DateTime(2012, 1, 14));
        account.Withdraw(500);

        // Act
        account.PrintStatement();

        // Assert
        var expected = new StringBuilder();
        expected.AppendLine("Date       || Amount || Balance");
        expected.AppendLine("14/01/2012 || -500   || 2500");
        expected.AppendLine("13/01/2012 || 2000   || 3000");
        expected.AppendLine("10/01/2012 || 1000   || 1000");

        Assert.Equal(expected.ToString(), printer.GetOutput());
    }
}