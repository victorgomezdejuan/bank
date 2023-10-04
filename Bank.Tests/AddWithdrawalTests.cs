namespace Bank.Tests;

public class AddWithdrawalTests
{
    [Fact]
    public void WithdrawalAsFirstEntry()
    {
        List<IAccountEntry> entries = new();
        var account = new Account(entries);
        var withdrawal = new Withdrawal(new DateOnly(2021, 1, 1), 100);

        account.AddEntry(withdrawal);

        Assert.Single(entries);
        Assert.Equal(withdrawal, entries[0]);
    }

    [Fact]
    public void WithdrawalAsSecondEntry()
    {
        List<IAccountEntry> entries = new();
        var account = new Account(entries);
        var withdrawal = new Withdrawal(new DateOnly(2021, 1, 1), 100);
        var withdrawal2 = new Withdrawal(new DateOnly(2021, 1, 2), 200);

        account.AddEntry(withdrawal);
        account.AddEntry(withdrawal2);

        Assert.Equal(2, entries.Count);
        Assert.Equal(withdrawal2, entries[1]);
    }
}