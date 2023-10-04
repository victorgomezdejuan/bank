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

    [Fact]
    public void PositiveAmountIsValid()
    {
        var withdrawal = new Withdrawal(new DateOnly(2021, 1, 1), 100);
        
        Assert.Equal(new DateOnly(2021, 1, 1), withdrawal.Date);
        Assert.Equal(100, withdrawal.Amount);
    }

    [Fact]
    public void CalculateAmountWithSignReturnsNegativeAmount()
    {
        var irrelevantDate = new DateOnly(2021, 1, 1);
        var withdrawal = new Withdrawal(irrelevantDate, 100);
        
        Assert.Equal(-100, withdrawal.CalculateAmountWithSign());
    }
}