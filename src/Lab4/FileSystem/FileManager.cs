using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class FileManager : IFileManager
{
    private readonly IFileSystem _fileSystem;

    public FileManager(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public void Move(string? sourcePath, string? destinationPath)
    {
        if (string.IsNullOrEmpty(sourcePath))
        {
            throw new ArgumentNullException(nameof(sourcePath), "Исходный путь не может быть нулевым или пустым");
        }

        if (string.IsNullOrEmpty(destinationPath))
        {
            throw new ArgumentNullException(nameof(destinationPath), "Путь назначения не может быть нулевым или пустым");
        }

        _fileSystem.MoveFile(sourcePath, destinationPath);
    }

    public void Copy(string? sourcePath, string? destinationPath)
    {
        _fileSystem.CopyFile(sourcePath, destinationPath);
    }

    public void Delete(string? path)
    {
        _fileSystem.DeleteFile(path);
    }

    public void Rename(string? path, string? newName)
    {
        _fileSystem.RenameFile(path, newName);
    }
}
