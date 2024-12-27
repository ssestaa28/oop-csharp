namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface IAtmService
{
    IAccount? GetAccountById(int accountId);

    decimal? CheckBalance(IAccount account);

    void Deposit(IAccount account, decimal amount);

    void Withdraw(IAccount account, decimal amount);

    ICollection<ITransaction> GetTransactionHistory(IAccount account);
}
