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
        printService.PrintLine("Date       || Amount || Balance");

        int balance = 0;

        foreach (var entry in account.GetEntries().OrderByDescending(e => e.Date))
        {
            balance += entry.CalculateAmountWithSign();
            printService.PrintLine($"{entry.Date:dd/MM/yyyy} || {entry.CalculateAmountWithSign()} || {balance}");
        }
    }
}