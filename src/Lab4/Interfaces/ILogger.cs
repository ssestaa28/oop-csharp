namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface ILogger
{
    void Log(string message);

    void LogError(string errorMessage);
}
