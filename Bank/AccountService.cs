namespace Bank;

public class AccountService : IAccountService
{
    private readonly ITimeProvider timeService;
    private readonly IPrinter printService;

    public AccountService(ITimeProvider timeService, IPrinter printService)
    {
        this.timeService = timeService;
        this.printService = printService;
    }

    public void Deposit(int amount)
    {
        throw new NotImplementedException();
    }

    public void PrintStatement()
    {
        throw new NotImplementedException();
    }

    public void Withdraw(int amount)
    {
        throw new NotImplementedException();
    }
}