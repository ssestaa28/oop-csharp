using Dapper;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence;

public class AccountRepository : IAccountRepository
{
    public IDbConnection Connection { get; }

    public AccountRepository(IDbConnection connection)
    {
        Connection = connection;
    }

    public IAccount? GetAccountById(int accountId)
    {
        string query = "SELECT * FROM accounts WHERE id = @Id";
        return Connection.QueryFirstOrDefault<Account>(query, new { Id = accountId });
    }

    public void UpdateAccount(IAccount account)
    {
        string query = "UPDATE accounts SET balance = @Balance WHERE id = @Id";
        Connection.Execute(query, new { account.Balance, account.Id });
    }

    public void SaveAccount(IAccount account)
    {
        string query = "INSERT INTO accounts (account_number, pin, balance) VALUES (@AccountNumber, @Pin, @Balance)";
        Connection.Execute(query, account);
    }

    public void UpdateBalance(int accountId, decimal newBalance)
    {
        string query = "UPDATE accounts SET balance = @NewBalance WHERE id = @Id";
        Connection.Execute(query, new { NewBalance = newBalance, Id = accountId });
    }
}
