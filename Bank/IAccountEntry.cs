namespace Bank;

public interface IAccountEntry
{
    DateOnly Date { get; }
    
    int CalculateAmountWithSign();
}