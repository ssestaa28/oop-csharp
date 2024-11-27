using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly IFileSystem _fileSystem;

    public string Name => "file show";

    public string[] Arguments { get; set; } = Array.Empty<string>();

    public FileShowCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public void Execute(string[] args)
    {
        if (args.Length < 1)
        {
            throw new ArgumentException("Путь необходим для команды показа файла", nameof(args));
        }

        string path = args[0];
        string? content = _fileSystem.ReadFile(path);
        if (string.IsNullOrEmpty(content))
        {
            Console.WriteLine($"Файл '{path}' пуст или не читается");
            return;
        }

        Console.WriteLine($"Содержимое файла {path}:\n{content}");
    }
}
