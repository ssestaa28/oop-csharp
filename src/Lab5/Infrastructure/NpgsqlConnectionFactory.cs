using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Npgsql;
using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure;

public class NpgsqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public NpgsqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
