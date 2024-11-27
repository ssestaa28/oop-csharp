using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;
using Moq;
using Xunit;

namespace Lab4.Tests.Commands;

public class DisconnectCommandTests
{
    [Fact]
    public void Execute_ShouldDisconnectFileSystem()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var command = new DisconnectCommand(mockFileSystem.Object);

        command.Execute(Array.Empty<string>());

        mockFileSystem.Verify(fs => fs.Disconnect(), Times.Once);
    }
}
