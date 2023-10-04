namespace Bank.Tests;

public class DepositTests
{
    [Fact]
    public void AmountZeroIsNotValid()
    {
        static void action() => new Deposit(new DateOnly(2021, 1, 1), 0);

        Assert.Throws<ArgumentException>(action);
    }
}