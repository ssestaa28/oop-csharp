using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Dispatcher;
using Moq;
using Xunit;

namespace Lab3.Tests.Dispatching;

public class MessageDispatcherTests
{
    [Fact]
    public void Should_DispatchMessage_ToAllRecipients()
    {
        var dispatcher = new MessageDispatcher();
        var message = new Mock<IMessage>();
        var recipient1 = new Mock<IRecipient>();
        var recipient2 = new Mock<IRecipient>();
        var recipients = new List<IRecipient> { recipient1.Object, recipient2.Object };

        dispatcher.DispatchMessage(message.Object, recipients);

        recipient1.Verify(r => r.ReceiveMessage(message.Object), Times.Once);
        recipient2.Verify(r => r.ReceiveMessage(message.Object), Times.Once);
    }
}