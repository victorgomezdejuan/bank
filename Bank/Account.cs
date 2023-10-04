
using System.Collections.ObjectModel;

namespace Bank;

public class Account
{
    private readonly List<IAccountEntry> entries;

    public Account() => entries = new List<IAccountEntry>();

    public Account(List<IAccountEntry> entries) => this.entries = entries;

    public void AddEntry(IAccountEntry entry) => entries.Add(entry);

    public ReadOnlyCollection<IAccountEntry> GetEntries() => entries.AsReadOnly();
}