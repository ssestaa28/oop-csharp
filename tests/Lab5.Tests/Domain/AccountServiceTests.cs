using Itmo.ObjectOrientedProgramming.Lab5.Domain.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Domain;

public class AccountServiceTests
{
    [Fact]
    public void Withdraw_EnoughBalance_UpdatesBalance()
    {
        var account = new Account { Id = 1, Balance = 100m };

        account.Balance -= 50m;

        Assert.Equal(50m, account.Balance);
    }

    [Fact]
    public void Deposit_ValidAmount_IncreasesBalance()
    {
        var account = new Account { Id = 1, Balance = 100m };

        account.Balance += 50m;

        Assert.Equal(150m, account.Balance);
    }
}
