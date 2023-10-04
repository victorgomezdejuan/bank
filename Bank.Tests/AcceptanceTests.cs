using System.Text;
using Bank.Tests.Mocks;

namespace Bank.Tests;

public class AcceptanceTests
{
    [Fact(Skip = "Acceptance test to be run after whole implementation is done")]
    public void StatementIsCorrectlyPrintedForAnAccountWithSeveralEntries()
    {
        // Arrange
        var timeProvider = new MockTimeProvider();
        var printer = new MockPrinter();
        var accountService = new AccountService(timeProvider, printer);

        timeProvider.SetCurrentDate(new DateOnly(2012, 1, 10));
        accountService.Deposit(1000);

        timeProvider.SetCurrentDate(new DateOnly(2012, 1, 13));
        accountService.Deposit(2000);

        timeProvider.SetCurrentDate(new DateOnly(2012, 1, 14));
        accountService.Withdraw(500);

        // Act
        accountService.PrintStatement();

        // Assert
        var expectedStatement = new StringBuilder();
        expectedStatement.AppendLine("Date       || Amount || Balance");
        expectedStatement.AppendLine("14/01/2012 || -500   || 2500");
        expectedStatement.AppendLine("13/01/2012 || 2000   || 3000");
        expectedStatement.AppendLine("10/01/2012 || 1000   || 1000");

        Assert.Equal(expectedStatement.ToString(), printer.GetOutput());
    }
}