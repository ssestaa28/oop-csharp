using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

public class Account : IAccount
{
    public int Id { get; set; }

    public string AccountNumber { get; set; } = string.Empty;

    public string Pin { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    private readonly List<ITransaction> _transactions = new();

    public ICollection<ITransaction> Transactions => _transactions.AsReadOnly();
}
