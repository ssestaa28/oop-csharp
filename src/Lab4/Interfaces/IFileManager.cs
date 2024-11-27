namespace Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;

public interface IFileManager
{
    void Move(string sourcePath, string destinationPath);

    void Copy(string sourcePath, string destinationPath);

    void Delete(string path);

    void Rename(string path, string newName);
}
