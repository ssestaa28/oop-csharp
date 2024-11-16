using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Logging;

public class ConsoleLogger : ILogger
{
    public void Log(string? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Console.WriteLine($"Log: {message}");
    }
}
