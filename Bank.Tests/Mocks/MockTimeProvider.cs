
namespace Bank.Tests.Mocks;

public class MockTimeProvider : ITimeProvider
{
    private DateOnly currentDate;

    public DateOnly CurrentDate => currentDate;

    internal void SetCurrentDate(DateOnly date) => currentDate = date;
}