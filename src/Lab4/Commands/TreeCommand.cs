using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeCommand : ICommand
{
    public string Name => "tree";

    public string[] Arguments { get; set; } = Array.Empty<string>();

    private readonly IFileSystem _fileSystem;

    public TreeCommand(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public void Execute(string[] args)
    {
        DirectoryModel? tree = _fileSystem.GetDirectoryTree(".");
        Console.WriteLine(tree?.ToString() ?? "No directory structure found.");
    }
}
