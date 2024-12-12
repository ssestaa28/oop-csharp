namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface ITransactionRepository
{
    void AddTransaction(ITransaction transaction);

    ICollection<ITransaction>? GetTransactionsByAccountId(int accountId);

    void DeleteTransactionsByAccountId(int accountId);
}