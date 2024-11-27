using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    public string Name => "connect";

    private readonly IFileSystem _fileSystem;

    public string[] Arguments { get; set; } = Array.Empty<string>();

    public ConnectCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public void Execute(string[] args)
    {
        if (args.Length < 1)
        {
            throw new ArgumentException("Для команды копирования требуется исходный и целевой путь", nameof(args));
        }

        string address = args[0];
        _fileSystem.Connect(address);
        Console.WriteLine($"Connected to {address}");
    }
}
