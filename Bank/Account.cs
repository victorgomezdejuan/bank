
namespace Bank;

public class Account
{
    private readonly ICollection<IAccountEntry> entries;

    public Account(ICollection<IAccountEntry> entries) => this.entries = entries;

    public void AddEntry(IAccountEntry entry) => entries.Add(entry);
}