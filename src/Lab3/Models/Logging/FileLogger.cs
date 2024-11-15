using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logging;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string? filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public void Log(string? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        File.AppendAllText(_filePath, message + "\n");
    }
}
