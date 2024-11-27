using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Moq;
using Xunit;

namespace Lab4.Tests.Parsers;

public class CommandParserTests
{
    private static readonly string[] DisconnectArgs = Array.Empty<string>();
    private static readonly string[] TreeListArgs = new[] { "-d", "3" };

    [Theory]
    [InlineData("disconnect", "disconnect", nameof(DisconnectArgs))]
    [InlineData("tree list -d 3", "tree list", nameof(TreeListArgs))]
    public void ParseCommand_ShouldParseCorrectly(string input, string expectedCommand, string argsField)
    {
        string[] expectedArgs = argsField switch
        {
            nameof(DisconnectArgs) => DisconnectArgs,
            nameof(TreeListArgs) => TreeListArgs,
            _ => throw new ArgumentException("Недопустимое имя поля аргумента"),
        };

        var mockDisconnectCommand = new Mock<ICommand>();
        mockDisconnectCommand.Setup(c => c.Name).Returns("disconnect");
        mockDisconnectCommand.Setup(c => c.Arguments).Returns(DisconnectArgs);

        var mockTreeListCommand = new Mock<ICommand>();
        mockTreeListCommand.Setup(c => c.Name).Returns("tree list");
        mockTreeListCommand.Setup(c => c.Arguments).Returns(TreeListArgs);

        var commands = new List<ICommand>
        {
        mockDisconnectCommand.Object,
        mockTreeListCommand.Object,
        };

        var parser = new CommandParser(commands);

        ICommand? resultCommand = parser.Parse(input);

        Assert.NotNull(resultCommand);
        Assert.Equal(expectedCommand, resultCommand.Name);
        Assert.Equal(expectedArgs, resultCommand.Arguments);
    }
}



