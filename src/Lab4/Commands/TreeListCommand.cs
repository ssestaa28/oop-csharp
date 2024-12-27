using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly IFileSystemNavigator _navigator;
    private readonly IAppConfig _config;

    public string Name => "tree list";

    public string[] Arguments { get; set; } = Array.Empty<string>();

    public TreeListCommand(IFileSystemNavigator navigator, IAppConfig config)
    {
        _navigator = navigator ?? throw new ArgumentNullException(nameof(navigator));
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public void Execute(string[] args)
    {
        int depth = _config.DefaultTreeDepth;
        DirectoryModel? result = _navigator.NavigateTo(".", depth);
        Console.WriteLine($"Directory: {result?.Name}, Path: {result?.Path}");
    }

    private void PrintDirectoryModel(DirectoryModel model, int indent)
    {
        string indentStr = new string(' ', indent * 2);
        Console.WriteLine($"{indentStr}{model.Name}");

        foreach (FileModel file in model.Files)
        {
            Console.WriteLine($"{indentStr}  {file.Name}");
        }

        foreach (DirectoryModel subDir in model.SubDirectories)
        {
            PrintDirectoryModel(subDir, indent + 1);
        }
    }
}
