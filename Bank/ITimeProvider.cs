namespace Bank;

public interface ITimeProvider
{
    DateOnly CurrentDate { get; }
}