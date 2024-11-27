using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface IFileSystem
{
    void Connect(string? address);

    void Disconnect();

    DirectoryModel? GetDirectoryTree(string? path, int depth = 1);

    string? ReadFile(string? path);

    void MoveFile(string? sourcePath, string? destinationPath);

    void CopyFile(string? sourcePath, string? destinationPath);

    void DeleteFile(string? path);

    void RenameFile(string? path, string? newName);
}
