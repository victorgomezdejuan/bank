namespace Bank.Tests;

public class DepositTests
{
    [Fact]
    public void ZeroAmountIsNotValid()
    {
        static void action() => new Deposit(new DateOnly(2021, 1, 1), 0);

        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void NegativeAmountIsNotValid()
    {
        static void action() => new Deposit(new DateOnly(2021, 1, 1), -100);

        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void PositiveAmountIsValid()
    {
        var deposit = new Deposit(new DateOnly(2021, 1, 1), 100);
        
        Assert.Equal(new DateOnly(2021, 1, 1), deposit.Date);
        Assert.Equal(100, deposit.Amount);
    }

    [Fact]
    public void CalculateAmountWithSignReturnsPositiveAmount()
    {
        var irrelevantDate = new DateOnly(2021, 1, 1);
        var deposit = new Deposit(irrelevantDate, 100);
        
        Assert.Equal(100, deposit.CalculateAmountWithSign());
    }
}