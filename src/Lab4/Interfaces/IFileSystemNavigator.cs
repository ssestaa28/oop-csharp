using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;

public interface IFileSystemNavigator
{
    DirectoryModel? NavigateTo(string path, int depth = 1);
}
