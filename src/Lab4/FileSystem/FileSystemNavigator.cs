using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class FileSystemNavigator : IFileSystemNavigator
{
    private readonly IFileSystem _fileSystem;

    public FileSystemNavigator(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public DirectoryModel? NavigateTo(string? path, int depth = 1)
    {
        return _fileSystem.GetDirectoryTree(path, depth);
    }
}
