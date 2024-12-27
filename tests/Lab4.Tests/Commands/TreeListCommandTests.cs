using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Moq;
using Xunit;

namespace Lab4.Tests.Commands;

public class TreeListCommandTests
{
    [Fact]
    public void Execute_ShouldDisplayTreeList()
    {
        var mockNavigator = new Mock<IFileSystemNavigator>();
        var mockConfig = new Mock<IAppConfig>();
        mockConfig.Setup(c => c.DefaultTreeDepth).Returns(2);

        var directoryModel = new DirectoryModel { Name = "Test", Path = "/Test" };
        mockNavigator.Setup(n => n.NavigateTo(".", 2)).Returns(directoryModel);

        var command = new TreeListCommand(mockNavigator.Object, mockConfig.Object);

        command.Execute(Array.Empty<string>());

        mockNavigator.Verify(n => n.NavigateTo(".", 2), Times.Once);
    }
}

