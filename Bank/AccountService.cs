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
        List<string> statementLines = new();
        int balance = 0;

        foreach (var entry in account.GetEntries().OrderBy(e => e.Date))
        {
            balance += entry.CalculateAmountWithSign();
            statementLines.Add($"{entry.Date:dd/MM/yyyy} || {entry.CalculateAmountWithSign(),-6} || {balance}");
        }

        statementLines.Add("Date       || Amount || Balance");

        foreach (var line in statementLines.AsEnumerable().Reverse())
        {
            printService.PrintLine(line);
        }
    }
}