using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : ICommand
{
    public string Name => "copy";

    public string[] Arguments { get; set; } = Array.Empty<string>();

    private readonly IFileSystem _fileSystem;

    public FileCopyCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public void Execute(string[] args)
    {
        if (args.Length < 2)
        {
            throw new ArgumentException("Для команды копирования требуется исходный и целевой путь", nameof(args));
        }

        string sourcePath = args[0];
        string destinationPath = args[1];
        _fileSystem.CopyFile(sourcePath, destinationPath);
        Console.WriteLine($"File copied from {sourcePath} to {destinationPath}");
    }
}
