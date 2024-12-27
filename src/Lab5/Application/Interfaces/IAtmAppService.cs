using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;

public interface IAtmAppService
{
    void ExecuteAtmOperations();

    (bool IsAuthenticated, IAccount? Account) AuthenticateUser(string accountNumber, string pin);

    decimal? GetBalance(IAccount account);

    bool Deposit(IAccount account, decimal amount);

    bool Withdraw(IAccount account, decimal amount);

    ICollection<ITransaction>? GetTransactionHistory(IAccount account);

    IAccount? GetAccountById(int accountId);
}
