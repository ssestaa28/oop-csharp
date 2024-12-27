using Dapper;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence;

public class AccountDao : IAccountRepository
{
    private IDbConnectionFactory ConnectionFactory { get; }

    public AccountDao(IDbConnectionFactory connectionFactory)
    {
        ConnectionFactory = connectionFactory;
    }

    public IAccount? GetAccountById(int accountId)
    {
        System.Data.IDbConnection connection = ConnectionFactory.CreateConnection();
        string query = "SELECT * FROM accounts WHERE id = @Id";
        return connection.QueryFirstOrDefault<IAccount>(query, new { Id = accountId });
    }

    public void UpdateAccount(IAccount account)
    {
        System.Data.IDbConnection connection = ConnectionFactory.CreateConnection();
        string query = "UPDATE accounts SET account_number = @AccountNumber, pin = @Pin, balance = @Balance WHERE id = @Id";
        connection.Execute(query, new { account.AccountNumber, account.Pin, account.Balance, account.Id });
    }

    public void SaveAccount(IAccount account)
    {
        System.Data.IDbConnection connection = ConnectionFactory.CreateConnection();
        string query = "INSERT INTO accounts (account_number, pin, balance) VALUES (@AccountNumber, @Pin, @Balance)";
        connection.Execute(query, new { account.AccountNumber, account.Pin, account.Balance });
    }

    public void UpdateBalance(int accountId, decimal newBalance)
    {
        System.Data.IDbConnection connection = ConnectionFactory.CreateConnection();
        string query = "UPDATE accounts SET balance = @Balance WHERE id = @Id";
        connection.Execute(query, new { Balance = newBalance, Id = accountId });
    }
}
