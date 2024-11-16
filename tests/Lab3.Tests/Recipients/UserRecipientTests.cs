using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Recipient;
using Moq;
using Xunit;

namespace Lab3.Tests.Recipients;

public class UserRecipientTests
{
    [Fact]
    public void Should_SaveMessageAsUnread_When_MessageReceived()
    {
        var user = new UserRecipient("User1");
        var message = new Mock<IMessage>();
        message.Setup(m => m.ImportanceLevel).Returns(2);
        message.Setup(m => m.GetHashCode()).Returns(1);
        message.Setup(m => m.Equals(It.IsAny<IMessage>())).Returns(true);

        user.ReceiveMessage(message.Object);

        Assert.Contains(message.Object, user.Messages);
        Assert.False(user.MessageStatus[message.Object]);
    }

    [Fact]
    public void Should_MarkMessageAsRead_When_MarkingUnreadMessageAsRead()
    {
        var user = new UserRecipient("User1");
        var message = new Mock<IMessage>();
        message.Setup(m => m.ImportanceLevel).Returns(2);
        message.Setup(m => m.GetHashCode()).Returns(1);
        message.Setup(m => m.Equals(It.IsAny<IMessage>())).Returns(true);

        user.ReceiveMessage(message.Object);
        user.MarkAsRead(message.Object);

        Assert.True(user.MessageStatus[message.Object]);
    }

    [Fact]
    public void Should_ThrowException_When_MarkingAlreadyReadMessageAsRead()
    {
        var user = new UserRecipient("User1");
        var message = new Mock<IMessage>();
        message.Setup(m => m.ImportanceLevel).Returns(2);
        message.Setup(m => m.GetHashCode()).Returns(1);
        message.Setup(m => m.Equals(It.IsAny<IMessage>())).Returns(true);

        user.ReceiveMessage(message.Object);
        user.MarkAsRead(message.Object);

        Assert.Throws<InvalidOperationException>(() => user.MarkAsRead(message.Object));
    }

    [Fact]
    public void Should_NotReceiveMessage_When_MessageImportanceBelowFilterLevel()
    {
        var user = new UserRecipient("User1") { ImportanceFilter = 5 };
        var message = new Mock<IMessage>();
        message.Setup(m => m.ImportanceLevel).Returns(3);

        user.ReceiveMessage(message.Object);

        Assert.DoesNotContain(message.Object, user.Messages);
    }
}
