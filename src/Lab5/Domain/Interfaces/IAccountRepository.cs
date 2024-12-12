namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface IAccountRepository
{
    IAccount? GetAccountById(int accountId);

    void UpdateAccount(IAccount account);

    void SaveAccount(IAccount account);

    void UpdateBalance(int accountId, decimal newBalance);
}