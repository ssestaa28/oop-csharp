using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class DirectoryModel
{
    public string? Name { get; set; }

    public string? Path { get; set; }

    public Collection<FileModel> Files { get; } = new Collection<FileModel>();

    public Collection<DirectoryModel> SubDirectories { get; } = new Collection<DirectoryModel>();
}