using Itmo.ObjectOrientedProgramming.Lab5.Application.Services;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Application;

public class AtmAppServiceTests
{
    [Fact]
    public void Withdraw_EnoughBalance_UpdatesAccountBalance()
    {
        var account = new Mock<IAccount>();
        account.Setup(a => a.Balance).Returns(100m);

        var accountRepositoryMock = new Mock<IAccountRepository>();
        var authenticationServiceMock = new Mock<IAuthenticationService>();
        var atmServiceMock = new Mock<IAtmService>();

        var atmAppService = new AtmAppService(atmServiceMock.Object, authenticationServiceMock.Object, accountRepositoryMock.Object);

        accountRepositoryMock.Setup(repo => repo.GetAccountById(It.IsAny<int>())).Returns(account.Object);

        atmServiceMock
            .Setup(service => service.Withdraw(account.Object, 50m))
            .Callback<IAccount, decimal>((acc, amount) => account.Setup(a => a.Balance).Returns(50m));

        bool result = atmAppService.Withdraw(account.Object, 50m);

        Assert.True(result);
        Assert.Equal(50m, account.Object.Balance);
        atmServiceMock.Verify(service => service.Withdraw(account.Object, 50m), Times.Once);
    }

    [Fact]
    public void Withdraw_NotEnoughBalance_ReturnsFalse()
    {
        var account = new Mock<IAccount>();
        account.Setup(a => a.Balance).Returns(30m);

        var accountRepositoryMock = new Mock<IAccountRepository>();
        var authenticationServiceMock = new Mock<IAuthenticationService>();
        var atmServiceMock = new Mock<IAtmService>();

        var atmAppService = new AtmAppService(atmServiceMock.Object, authenticationServiceMock.Object, accountRepositoryMock.Object);

        accountRepositoryMock.Setup(repo => repo.GetAccountById(It.IsAny<int>())).Returns(account.Object);

        atmServiceMock
            .Setup(service => service.Withdraw(It.IsAny<IAccount>(), It.IsAny<decimal>()))
            .Callback<IAccount, decimal>((acc, amount) =>
            {
                if (acc.Balance < amount)
                {
                    throw new InvalidOperationException("Insufficient funds");
                }
            });

        bool result;
        try
        {
            result = atmAppService.Withdraw(account.Object, 50m);
        }
        catch (InvalidOperationException)
        {
            result = false;
        }

        Assert.False(result);
        accountRepositoryMock.Verify(repo => repo.UpdateAccount(It.IsAny<IAccount>()), Times.Never);
        atmServiceMock.Verify(service => service.Withdraw(account.Object, 50m), Times.Once);
    }

    [Fact]
    public void Deposit_ValidAmount_UpdatesAccountBalance()
    {
        var account = new Mock<IAccount>();
        account.Setup(a => a.Balance).Returns(100m);

        var accountRepositoryMock = new Mock<IAccountRepository>();
        var authenticationServiceMock = new Mock<IAuthenticationService>();
        var atmServiceMock = new Mock<IAtmService>();

        var atmAppService = new AtmAppService(atmServiceMock.Object, authenticationServiceMock.Object, accountRepositoryMock.Object);

        accountRepositoryMock.Setup(repo => repo.GetAccountById(It.IsAny<int>())).Returns(account.Object);

        atmServiceMock
            .Setup(service => service.Deposit(account.Object, 50m))
            .Callback<IAccount, decimal>((acc, amount) => account.Setup(a => a.Balance).Returns(150m));

        bool result = atmAppService.Deposit(account.Object, 50m);

        Assert.True(result);
        Assert.Equal(150m, account.Object.Balance);
        atmServiceMock.Verify(service => service.Deposit(account.Object, 50m), Times.Once);
    }

    [Fact]
    public void AuthenticateUser_ValidCredentials_ReturnsAuthenticatedAccount()
    {
        var account = new Mock<IAccount>();
        var authenticationServiceMock = new Mock<IAuthenticationService>();
        authenticationServiceMock.Setup(auth => auth.AuthenticateUser("12345", "pin123")).Returns(account.Object);

        var accountRepositoryMock = new Mock<IAccountRepository>();
        var atmServiceMock = new Mock<IAtmService>();
        var atmAppService = new AtmAppService(atmServiceMock.Object, authenticationServiceMock.Object, accountRepositoryMock.Object);

        (bool IsAuthenticated, IAccount? Account) result = atmAppService.AuthenticateUser("12345", "pin123");

        Assert.True(result.IsAuthenticated);
        Assert.NotNull(result.Account);
    }

    [Fact]
    public void GetTransactionHistory_ValidAccount_ReturnsTransactions()
    {
        var account = new Mock<IAccount>();
        var transactions = new List<ITransaction>
        {
            new Mock<ITransaction>().Object,
            new Mock<ITransaction>().Object,
        };

        var atmServiceMock = new Mock<IAtmService>();
        atmServiceMock.Setup(atm => atm.GetTransactionHistory(account.Object)).Returns(transactions);

        var authenticationServiceMock = new Mock<IAuthenticationService>();
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var atmAppService = new AtmAppService(atmServiceMock.Object, authenticationServiceMock.Object, accountRepositoryMock.Object);

        ICollection<ITransaction>? result = atmAppService.GetTransactionHistory(account.Object);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}