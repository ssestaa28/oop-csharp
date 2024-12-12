using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.ConsoleApp;

public class ConsoleReader : IConsoleReader
{
    public string ReadLine()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}
