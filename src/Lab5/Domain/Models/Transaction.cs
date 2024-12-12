using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

public class Transaction : ITransaction
{
    public int Id { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal Amount { get; set; }

    public string Type { get; set; } = string.Empty;

    public int AccountId { get; set; }
}
