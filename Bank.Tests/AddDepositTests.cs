namespace Bank.Tests;

public class AddDepositTests
{
    [Fact]
    public void DepositAsFirstEntry()
    {
        List<IAccountEntry> entries = new();
        var account = new Account(entries);
        var deposit = new Deposit(new DateOnly(2021, 1, 1), 100);

        account.AddEntry(deposit);

        Assert.Single(entries);
        Assert.Equal(deposit, entries[0]);
    }

    [Fact]
    public void DepositAsSecondEntry()
    {
        List<IAccountEntry> entries = new();
        var account = new Account(entries);
        var deposit = new Deposit(new DateOnly(2021, 1, 1), 100);
        var deposit2 = new Deposit(new DateOnly(2021, 1, 2), 200);

        account.AddEntry(deposit);
        account.AddEntry(deposit2);

        Assert.Equal(2, entries.Count);
        Assert.Equal(deposit2, entries[1]);
    }
}