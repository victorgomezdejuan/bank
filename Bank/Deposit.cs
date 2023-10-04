namespace Bank;

public class Deposit : IAccountEntry
{
    public Deposit(DateOnly date, int amount)
    {
        Date = date;
        Amount = amount;
    }

    public DateOnly Date { get; }

    public int Amount { get; }

    public int CalculateAmountWithSign() => Amount;
}
