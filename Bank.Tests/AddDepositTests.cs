namespace Bank.Tests;

public class AddDepositTests
{
    [Fact]
    public void DepositAsFirstEntry()
    {
        List<IAccountEntry> entries = new();
        var account = new Account(entries);
        var date = new DateOnly(2021, 1, 1);
        var deposit = new Deposit(date, 100);

        account.AddEntry(deposit);

        Assert.Single(entries);
        Assert.Equal(deposit, entries[0]);
    }
}