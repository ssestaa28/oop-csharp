using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private string? _currentPath;

    public void Connect(string? address)
    {
        if (string.IsNullOrEmpty(address))
        {
            throw new ArgumentNullException(nameof(address), "Адрес не может быть нулевым или пустым");
        }

        if (!Directory.Exists(address))
        {
            throw new DirectoryNotFoundException($"Путь '{address}' не существует");
        }

        _currentPath = address;
    }

    public void Disconnect()
    {
        _currentPath = null;
    }

    public DirectoryModel? GetDirectoryTree(string? path, int depth = 1)
    {
        if (_currentPath is null)
        {
            throw new InvalidOperationException("Файловая система не подключена");
        }

        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path), "Путь не может быть null или пустым");
        }

        string fullPath = Path.Combine(_currentPath, path);

        if (!Directory.Exists(fullPath))
        {
            throw new DirectoryNotFoundException($"Каталог '{fullPath}' не существует");
        }

        return GetDirectoryModel(fullPath, depth);
    }

    public string? ReadFile(string? path)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentNullException(nameof(path), "Путь не может быть null или пустым");

        string fullPath = GetFullPath(path);

        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"Файл '{fullPath}' не существует");

        return File.ReadAllText(fullPath);
    }

    public void MoveFile(string? sourcePath, string? destinationPath)
    {
        string fullSourcePath = GetFullPath(sourcePath);
        string fullDestinationPath = GetFullPath(destinationPath);

        if (!File.Exists(fullSourcePath))
            throw new FileNotFoundException($"Файл '{fullSourcePath}' не существует");

        File.Move(fullSourcePath, fullDestinationPath);
    }

    public void CopyFile(string? sourcePath, string? destinationPath)
    {
        string fullSourcePath = GetFullPath(sourcePath);
        string fullDestinationPath = GetFullPath(destinationPath);

        if (!File.Exists(fullSourcePath))
            throw new FileNotFoundException($"Файл '{fullSourcePath}' не существует");

        File.Copy(fullSourcePath, fullDestinationPath, overwrite: true);
    }

    public void DeleteFile(string? path)
    {
        string fullPath = GetFullPath(path);

        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"Файл '{fullPath}' не существует");

        File.Delete(fullPath);
    }

    public void RenameFile(string? path, string? newName)
    {
        if (string.IsNullOrEmpty(newName))
            throw new ArgumentNullException(nameof(newName), "Новое имя не может быть null или пустым");

        string fullPath = GetFullPath(path);

        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"Файл '{fullPath}' не существует");

        string directory = Path.GetDirectoryName(fullPath) ?? string.Empty;
        string newFullPath = Path.Combine(directory, newName);

        File.Move(fullPath, newFullPath);
    }

    private string GetFullPath(string? relativePath)
    {
        if (string.IsNullOrEmpty(relativePath))
            throw new ArgumentNullException(nameof(relativePath), "Путь не может быть null или пустым");

        return Path.Combine(_currentPath ?? string.Empty, relativePath);
    }

    private DirectoryModel GetDirectoryModel(string path, int depth)
    {
        var directory = new DirectoryModel
        {
            Name = Path.GetFileName(path),
            Path = path,
        };

        if (depth < 1) return directory;

        foreach (string file in Directory.GetFiles(path))
        {
            var fileInfo = new FileInfo(file);
            directory.Files.Add(new FileModel
            {
                Name = fileInfo.Name,
                Path = fileInfo.FullName,
                Size = fileInfo.Length,
            });
        }

        foreach (string subDir in Directory.GetDirectories(path))
        {
            DirectoryModel subDirectory = GetDirectoryModel(subDir, depth - 1);
            directory.SubDirectories.Add(subDirectory);
        }

        return directory;
    }
}