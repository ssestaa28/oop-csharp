using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class AppConfig : IAppConfig
{
    public int DefaultTreeDepth { get; set; } = 1;

    public string FileSymbol { get; set; } = "[FILE]";

    public string DirectorySymbol { get; set; } = "[DIR]";

    public string IndentSymbol { get; set; } = "  ";

    public string AppName { get; set; } = "File System Manager";

    public string WelcomeMessage { get; set; } = "Welcome to File System Manager! Type 'help' for a list of commands.";

    public string ExitMessage { get; set; } = "Exiting File System Manager. Goodbye!";
}
