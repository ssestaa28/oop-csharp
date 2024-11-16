using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Recipient;
using Moq;
using Xunit;

namespace Lab3.Tests.Recipients;

public class MessengerRecipientTests
{
    [Fact]
    public void Should_OutputMessage_When_MessageReceived()
    {
        var messenger = new Mock<IMessenger>();
        var message = new Mock<IMessage>();
        message.Setup(m => m.Body).Returns("Test message");
        message.Setup(m => m.ImportanceLevel).Returns(5);

        var recipient = new MessengerRecipient("TestMessenger", messenger.Object) { ImportanceFilter = 3 };

        recipient.ReceiveMessage(message.Object);

        messenger.Verify(m => m.SendMessage("Test message"), Times.Once);
    }
}