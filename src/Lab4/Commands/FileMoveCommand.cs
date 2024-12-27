using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    public string Name => "move";

    public string[] Arguments { get; set; } = Array.Empty<string>();

    private readonly IFileSystem _fileSystem;

    public FileMoveCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public void Execute(string[] args)
    {
        if (args.Length < 2)
        {
            throw new ArgumentException("Для команды перемещения требуется исходный и целевой путь", nameof(args));
        }

        string sourcePath = args[0];
        string destinationPath = args[1];
        _fileSystem.MoveFile(sourcePath, destinationPath);
        Console.WriteLine($"File moved from {sourcePath} to {destinationPath}");
    }
}
