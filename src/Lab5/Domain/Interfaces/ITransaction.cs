namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface ITransaction
{
    int Id { get; }

    DateTime TransactionDate { get; }

    decimal Amount { get; }

    string Type { get; }

    int AccountId { get; }
}
