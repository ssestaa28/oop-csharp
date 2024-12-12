namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;

public interface IAuthenticationService
{
    IAccount? AuthenticateUser(string accountNumber, string pin);

    bool AuthenticateAdmin(string password);
}
