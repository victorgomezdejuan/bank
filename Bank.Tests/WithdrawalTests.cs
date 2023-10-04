namespace Bank.Tests;

public class WithdrawalTests
{
    [Fact]
    public void ZeroAmountIsNotValid()
    {
        static void action() => new Withdrawal(new DateOnly(2021, 1, 1), 0);

        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void NegativeAmountIsNotValid()
    {
        static void action() => new Withdrawal(new DateOnly(2021, 1, 1), -100);

        Assert.Throws<ArgumentException>(action);
    }
}