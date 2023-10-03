
namespace Bank.Tests.Mocks;

public class MockPrinter : IPrinter
{
    public void PrintLine(string line)
    {
        throw new NotImplementedException();
    }

    internal IEnumerable<char> GetOutput()
    {
        throw new NotImplementedException();
    }
}