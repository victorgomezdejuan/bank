using Ardalis.GuardClauses;

namespace Bank;

public class Deposit : IAccountEntry
{
    public Deposit(DateOnly date, int amount)
    {
        Guard.Against.NegativeOrZero(amount, nameof(amount));

        Date = date;
        Amount = amount;
    }

    public DateOnly Date { get; }
    public int Amount { get; }

    public int CalculateAmountWithSign() => Amount;

    public override string ToString() => $"{Date:yyyy-MM-dd} | {Amount} |";

    public override bool Equals(object? obj) => obj is Deposit other && Equals(other);

    public bool Equals(Deposit other) => Date.Equals(other.Date) && Amount == other.Amount;

    public override int GetHashCode() => HashCode.Combine(Date, Amount);
}
