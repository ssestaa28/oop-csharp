using Dapper;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

public class TransactionRepository : ITransactionRepository
{
    private readonly IDbConnection _connection;

    public TransactionRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public void DeleteTransactionsByAccountId(int accountId)
    {
        string query = "DELETE FROM transactions WHERE account_id = @AccountId";
        _connection.Execute(query, new { AccountId = accountId });
    }

    public void AddTransaction(ITransaction transaction)
    {
        string query = "INSERT INTO transactions (date, amount, type, account_id) VALUES (@TransactionDate, @Amount, @Type, @AccountId)";
        _connection.Execute(query, transaction);
    }

    public ICollection<ITransaction>? GetTransactionsByAccountId(int accountId)
    {
        string query = "SELECT * FROM transactions WHERE account_id = @AccountId";
        return _connection.Query<Transaction>(query, new { AccountId = accountId })
                          .Cast<ITransaction>()
                          .ToList();
    }
}