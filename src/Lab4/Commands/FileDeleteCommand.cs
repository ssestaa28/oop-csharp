using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    public string Name => "delete";

    public string[] Arguments { get; set; } = Array.Empty<string>();

    private readonly IFileSystem _fileSystem;

    public FileDeleteCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public void Execute(string[] args)
    {
        if (args.Length < 1)
        {
            throw new ArgumentException("Для команды удаления требуется путь к файлу", nameof(args));
        }

        string filePath = args[0];
        _fileSystem.DeleteFile(filePath);
        Console.WriteLine($"File {filePath} deleted");
    }
}
