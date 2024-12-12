using Dapper;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence;

public class TransactionDao : ITransactionRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public TransactionDao(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public void AddTransaction(ITransaction transaction)
    {
        System.Data.IDbConnection connection = _connectionFactory.CreateConnection();
        string query = "INSERT INTO transactions (date, amount, type, account_id) VALUES (@Date, @Amount, @Type, @AccountId)";
        connection.Execute(query, transaction);
    }

    public ICollection<ITransaction>? GetTransactionsByAccountId(int accountId)
    {
        System.Data.IDbConnection connection = _connectionFactory.CreateConnection();
        string query = "SELECT * FROM transactions WHERE account_id = @AccountId";
        var transactions = connection.Query<Transaction>(query, new { AccountId = accountId }).ToList();
        return transactions.Cast<ITransaction>().ToList();
    }

    public void DeleteTransactionsByAccountId(int accountId)
    {
        System.Data.IDbConnection connection = _connectionFactory.CreateConnection();
        string query = "DELETE FROM transactions WHERE account_id = @AccountId";
        connection.Execute(query, new { AccountId = accountId });
    }
}
