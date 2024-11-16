using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Recipient;
using Moq;
using Xunit;

namespace Lab3.Tests.Logging;

public class LoggerTests
{
    [Fact]
    public void Should_LogMessage_When_MessageReceived()
    {
        var logger = new Mock<ILogger>();
        var user = new UserRecipient("User1") { ImportanceFilter = 1 };
        user.SetLogger(logger.Object);

        var message = new Mock<IMessage>();
        message.Setup(m => m.ImportanceLevel).Returns(2);
        message.Setup(m => m.Title).Returns("Test Message");

        user.ReceiveMessage(message.Object);

        logger.Verify(l => l.Log(It.IsAny<string>()), Times.Once);
    }
}
