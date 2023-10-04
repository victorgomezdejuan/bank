
using System.Text;

namespace Bank.Tests.Mocks;

public class MockPrinter : IPrinter
{
    private readonly StringBuilder output = new();

    public void PrintLine(string line) => output.AppendLine(line);

    internal string GetOutput() => output.ToString();
}