namespace Bank;

public class AccountService : IAccountService
{
    private readonly ITimeProvider timeService;
    private readonly IPrinter printService;
    private readonly Account account;

    public AccountService(ITimeProvider timeService, IPrinter printService)
    {
        this.timeService = timeService;
        this.printService = printService;
        account = new Account();
    }

    public void Deposit(int amount) => account.AddEntry(new Deposit(timeService.CurrentDate, amount));

    public void Withdraw(int amount) => account.AddEntry(new Withdrawal(timeService.CurrentDate, amount));

    public void PrintStatement()
    {
        foreach (var line in StatementLines())
        {
            printService.PrintLine(line);
        }
    }

    private IEnumerable<string> StatementLines()
    {
        var statementLines = new List<string>();
        int balance = 0;

        foreach (var entry in account.GetEntries().OrderBy(e => e.Date))
        {
            balance += entry.CalculateAmountWithSign();
            statementLines.Add(StatementEntry(entry, balance));
        }

        statementLines.Add(StatementHeader());

        return statementLines.AsEnumerable().Reverse();
    }

    private static string StatementHeader() => "Date       || Amount || Balance";

    private static string StatementEntry(IAccountEntry entry, int balance)
    {
        return $"{entry.Date:dd/MM/yyyy} || {entry.CalculateAmountWithSign(),-6} || {balance}";
    }
}