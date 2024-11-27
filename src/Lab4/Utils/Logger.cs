using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Utils;

public class Logger : ILogger
{
    private static Logger? _instance;

    public static Logger Instance => _instance ??= new Logger();

    private Logger() { }

    public void Log(string? message)
    {
        if (!string.IsNullOrEmpty(message))
            Console.WriteLine($"[INFO]: {message}");
    }

    public void LogError(string? errorMessage)
    {
        if (!string.IsNullOrEmpty(errorMessage))
            Console.WriteLine($"[ERROR]: {errorMessage}");
    }
}
