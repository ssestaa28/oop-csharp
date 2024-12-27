using System.Data;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
