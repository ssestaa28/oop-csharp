using Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

public class AtmAppService : IAtmAppService
{
    public IAtmService AtmService { get; }

    public IAuthenticationService AuthenticationService { get; }

    private IAccountRepository AccountRepository { get; }

    public AtmAppService(IAtmService atmService, IAuthenticationService authenticationService, IAccountRepository accountRepository)
    {
        AtmService = atmService;
        AuthenticationService = authenticationService;
        AccountRepository = accountRepository;
    }

    public void ExecuteAtmOperations()
    {
        Console.WriteLine("Welcome to the ATM!");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Authenticate User");
        Console.WriteLine("2. Check Balance");
        Console.WriteLine("3. Deposit Money");
        Console.WriteLine("4. Withdraw Money");
        Console.WriteLine("5. View Transaction History");
        Console.WriteLine("6. Exit");

        while (true)
        {
            Console.Write("Введите свой выбор: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AuthenticateUserOption();
                    break;
                case "2":
                    CheckBalanceOption();
                    break;
                case "3":
                    DepositMoneyOption();
                    break;
                case "4":
                    WithdrawMoneyOption();
                    break;
                case "5":
                    ViewTransactionHistoryOption();
                    break;
                case "6":
                    Console.WriteLine("Спасибо за использование банкомата. ПоКаПоКа");
                    return;
                default:
                    Console.WriteLine("Неверный пароль ПИК-ПИК-ПИК. Пожалуйста, трайни еще раз");
                    break;
            }
        }
    }

    public (bool IsAuthenticated, IAccount? Account) AuthenticateUser(string accountNumber, string pin)
    {
        IAccount? account = AuthenticationService.AuthenticateUser(accountNumber, pin);
        return (account != null, account);
    }

    public decimal? GetBalance(IAccount account)
    {
        return AtmService.CheckBalance(account);
    }

    public bool Deposit(IAccount account, decimal amount)
    {
        AtmService.Deposit(account, amount);
        return true;
    }

    public IAccount? GetAccountById(int accountId)
    {
        return AccountRepository.GetAccountById(accountId);
    }

    public bool Withdraw(IAccount account, decimal amount)
    {
        try
        {
            AtmService.Withdraw(account, amount);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public ICollection<ITransaction>? GetTransactionHistory(IAccount account)
    {
        return AtmService.GetTransactionHistory(account);
    }

    private void AuthenticateUserOption()
    {
        Console.Write("Введите номер счета: ");
        string? accountNumber = Console.ReadLine();
        Console.Write("Введите PINкод: ");
        string? pin = Console.ReadLine();

        if (!string.IsNullOrEmpty(accountNumber) && !string.IsNullOrEmpty(pin))
        {
            (bool isAuthenticated, IAccount? account) = AuthenticateUser(accountNumber, pin);

            if (isAuthenticated && account != null)
            {
                Console.WriteLine($"Велком, Account #{account.Id}");
            }
            else
            {
                Console.WriteLine("Аутентификация не удалась. Плиз, трайни еще раз");
            }
        }
        else
        {
            Console.WriteLine("Номер счета или PIN-код не могут быть пустыми");
        }
    }

    private void CheckBalanceOption()
    {
        Console.Write("Vvedi Account ID: ");
        if (int.TryParse(Console.ReadLine(), out int accountId))
        {
            IAccount? account = AtmService.GetAccountById(accountId);
            if (account != null)
            {
                decimal? balance = GetBalance(account);
                Console.WriteLine($"Your баланс is: {balance:C}");
            }
            else
            {
                Console.WriteLine("Аккаунта чет не вижу...");
            }
        }
        else
        {
            Console.WriteLine("Инвалид Account ID");
        }
    }

    private void DepositMoneyOption()
    {
        Console.Write("Введи Account ID: ");
        if (int.TryParse(Console.ReadLine(), out int accountId))
        {
            Console.Write("Введи amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                IAccount? account = AtmService.GetAccountById(accountId);
                if (account != null)
                {
                    Deposit(account, amount);
                    Console.WriteLine($"ДА ЭТО УСПЕХ, deposited {amount:C}.");
                }
                else
                {
                    Console.WriteLine("Аккаунта чет not found");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }
        else
        {
            Console.WriteLine("Invalid Account ID");
        }
    }

    private void WithdrawMoneyOption()
    {
        Console.Write("Введи Account ID: ");
        if (int.TryParse(Console.ReadLine(), out int accountId))
        {
            Console.Write("Введи amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                IAccount? account = AtmService.GetAccountById(accountId);
                if (account != null)
                {
                    if (Withdraw(account, amount))
                    {
                        Console.WriteLine($"СИИИИИИУУУУУ, этот успех, withdrew {amount:C}");
                    }
                    else
                    {
                        Console.WriteLine("Нет денег бро или что-то не так делаешь");
                    }
                }
                else
                {
                    Console.WriteLine("Аккаунт not found");
                }
            }
            else
            {
                Console.WriteLine("Invalid amount");
            }
        }
        else
        {
            Console.WriteLine("Invalid Account ID");
        }
    }

    private void ViewTransactionHistoryOption()
    {
        Console.Write("Введи Account ID: ");
        if (int.TryParse(Console.ReadLine(), out int accountId))
        {
            IAccount? account = AtmService.GetAccountById(accountId);
            if (account != null)
            {
                ICollection<ITransaction>? transactions = GetTransactionHistory(account);
                if (transactions != null && transactions.Count > 0)
                {
                    Console.WriteLine("Transaction History:");
                    foreach (ITransaction transaction in transactions)
                    {
                        Console.WriteLine($"- {transaction.TransactionDate}: {transaction.Type} {transaction.Amount:C}");
                    }
                }
                else
                {
                    Console.WriteLine("Не вижу твоих транзакций");
                }
            }
            else
            {
                Console.WriteLine("Account not found");
            }
        }
        else
        {
            Console.WriteLine("Invalid Account ID");
        }
    }
}
