using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    public string Name => "rename";

    public string[] Arguments { get; set; } = Array.Empty<string>();

    private readonly IFileSystem _fileSystem;

    public FileRenameCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public void Execute(string[] args)
    {
        if (args.Length < 2)
        {
            throw new ArgumentException("Для команды переименования требуется текущий путь и новое имя", nameof(args));
        }

        string filePath = args[0];
        string newName = args[1];
        _fileSystem.RenameFile(filePath, newName);
        Console.WriteLine($"File {filePath} renamed to {newName}");
    }
}
