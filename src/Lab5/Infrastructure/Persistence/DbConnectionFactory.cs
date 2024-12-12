using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Npgsql;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence;

public class DbConnectionFactory : IDbConnectionFactory
{
    private readonly string? _connectionString;

    public DbConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
