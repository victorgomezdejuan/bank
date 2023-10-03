
namespace Bank.Tests.Mocks;

public class MockTimeProvider : ITimeProvider
{
    public DateTime GetTime()
    {
        throw new NotImplementedException();
    }

    internal void SetTime(DateTime dateTime)
    {
        throw new NotImplementedException();
    }
}