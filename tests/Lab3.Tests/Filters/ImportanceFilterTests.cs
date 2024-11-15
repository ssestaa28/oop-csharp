using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Models.Recipient;
using Moq;
using Xunit;

namespace Lab3.Tests.Filters;

    public class ImportanceFilterTests
    {
        [Fact]
        public void Should_FilterOutMessage_When_ImportanceIsTooLow()
        {
            var user = new UserRecipient("User1") { ImportanceFilter = 5 };
            var message = new Mock<IMessage>();
            message.Setup(m => m.ImportanceLevel).Returns(3);

            user.ReceiveMessage(message.Object);

            Assert.DoesNotContain(message.Object, user.Messages);
        }

        [Fact]
        public void Should_ReceiveMessage_When_ImportanceMeetsOrExceedsFilter()
        {
            var user = new UserRecipient("User1") { ImportanceFilter = 3 };
            var messageMock = new Mock<IMessage>();
            messageMock.Setup(m => m.ImportanceLevel).Returns(3);
            messageMock.Setup(m => m.GetHashCode()).Returns(1);
            messageMock.Setup(m => m.Equals(It.IsAny<IMessage>())).Returns(true);

            user.ReceiveMessage(messageMock.Object);

            Assert.Contains(messageMock.Object, user.Messages);
        }
    }

