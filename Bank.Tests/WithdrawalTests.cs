namespace Bank.Tests;

public class WithdrawalTests
{
    [Fact]
    public void ZeroAmountIsNotValid()
    {
        static void action() => new Withdrawal(new DateOnly(2021, 1, 1), 0);

        Assert.Throws<ArgumentException>(action);
    }
}