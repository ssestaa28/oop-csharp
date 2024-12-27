namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface IAccount
{
    int Id { get; }

    string AccountNumber { get; }

    string Pin { get; }

    decimal Balance { get; }
}
