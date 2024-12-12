using Itmo.ObjectOrientedProgramming.Lab5.Application.Services;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Interfaces;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Application;

public class AdminAppServiceTests
{
    private readonly Mock<IAccountRepository> _accountRepositoryMock;
    private readonly Mock<ITransactionRepository> _transactionRepositoryMock;
    private readonly AdminAppService _adminAppService;

    public AdminAppServiceTests()
    {
        _accountRepositoryMock = new Mock<IAccountRepository>();
        _transactionRepositoryMock = new Mock<ITransactionRepository>();

        _adminAppService = new AdminAppService(
            "admin123",
            _accountRepositoryMock.Object,
            _transactionRepositoryMock.Object);
    }

    [Fact]
    public void AuthenticateAdmin_CorrectPassword_ReturnsTrue()
    {
        const string correctPassword = "admin123";
        bool result = _adminAppService.AuthenticateAdmin(correctPassword);
        Assert.True(result);
    }

    [Fact]
    public void AuthenticateAdmin_IncorrectPassword_ReturnsFalse()
    {
        const string incorrectPassword = "wrongPassword";
        bool result = _adminAppService.AuthenticateAdmin(incorrectPassword);
        Assert.False(result);
    }

    [Fact]
    public void ResetAccount_InvalidAccountId_ReturnsFalse()
    {
        _accountRepositoryMock
            .Setup(repo => repo.GetAccountById(It.IsAny<int>()))
            .Returns((IAccount?)null);

        bool result = _adminAppService.ResetAccount(999);

        Assert.False(result);
        _accountRepositoryMock.Verify(repo => repo.UpdateAccount(It.IsAny<IAccount>()), Times.Never);
    }
}
