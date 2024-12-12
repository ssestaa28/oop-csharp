using Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

public class AdminAppService : IAdminAppService
{
    public string SystemPassword { get; }

    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public AdminAppService(
        string systemPassword,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository)
    {
        SystemPassword = systemPassword;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public bool AuthenticateAdmin(string password)
    {
        return password == SystemPassword;
    }

    public bool ResetAccount(int accountId)
    {
        IAccount? account = _accountRepository.GetAccountById(accountId);
        if (account == null)
        {
            return false;
        }

        _accountRepository.UpdateBalance(accountId, 0);
        _transactionRepository.DeleteTransactionsByAccountId(accountId);

        return true;
    }

    public void CreateAccount(string accountNumber, string pin)
    {
        if (string.IsNullOrWhiteSpace(accountNumber) || string.IsNullOrWhiteSpace(pin))
        {
            throw new ArgumentException("Номер счета и PINкод не могут быть пустыми");
        }

        var newAccount = new Account
        {
            AccountNumber = accountNumber,
            Pin = pin,
            Balance = 0,
        };

        _accountRepository.SaveAccount(newAccount);
    }

    public void ExecuteAdminOperations()
    {
        Console.WriteLine("Выполнение административных операций.....................................");
    }
}
