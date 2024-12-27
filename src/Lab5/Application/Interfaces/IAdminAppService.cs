namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Interfaces;

public interface IAdminAppService
{
    void ExecuteAdminOperations();

    bool AuthenticateAdmin(string password);

    bool ResetAccount(int accountId);

    void CreateAccount(string accountNumber, string pin);
}
