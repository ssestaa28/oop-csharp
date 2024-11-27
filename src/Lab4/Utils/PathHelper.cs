namespace Itmo.ObjectOrientedProgramming.Lab4.Utils;

public class PathHelper
{
    public bool IsRelativePath(string? path)
    {
        return !string.IsNullOrEmpty(path) && !Path.IsPathRooted(path);
    }

    public string GetAbsolutePath(string? basePath, string? relativePath)
    {
        if (string.IsNullOrEmpty(basePath))
        {
            throw new ArgumentNullException(nameof(basePath), "Базовый путь не может быть нулевым или пустым");
        }

        if (string.IsNullOrEmpty(relativePath))
        {
            throw new ArgumentNullException(nameof(relativePath), "Относительный путь не может быть нулевым или пустым");
        }

        return Path.GetFullPath(Path.Combine(basePath, relativePath));
    }
}
