namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface IAppConfig
{
    int DefaultTreeDepth { get; }

    string FileSymbol { get; }

    string DirectorySymbol { get; }

    string IndentSymbol { get; }

    string AppName { get; }

    string WelcomeMessage { get; }

    string ExitMessage { get; }
}