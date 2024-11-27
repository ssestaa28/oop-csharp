using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public string Name => "disconnect";

    public string[] Arguments { get; set; } = Array.Empty<string>();

    private readonly IFileSystem _fileSystem;

    public DisconnectCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public void Execute(string[] args)
    {
        _fileSystem.Disconnect();
        Console.WriteLine("Disconnected from the file system");
    }
}
