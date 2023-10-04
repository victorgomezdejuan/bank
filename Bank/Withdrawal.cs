using Ardalis.GuardClauses;

namespace Bank;

public class Withdrawal : IAccountEntry
{
    public Withdrawal(DateOnly date, int amount)
    {
        Guard.Against.NegativeOrZero(amount, nameof(amount));

        Amount = amount;
        Date = date;
        
    }

    public DateOnly Date { get; }
    public int Amount { get; }

    public int CalculateAmountWithSign() => -Amount;

    public override string ToString() => $"{Date:yyyy-MM-dd} | | {Amount}";

    public override bool Equals(object? obj) => obj is Withdrawal other && Equals(other);

    public bool Equals(Withdrawal other) => Date.Equals(other.Date) && Amount == other.Amount;

    public override int GetHashCode() => HashCode.Combine(Date, Amount);
}