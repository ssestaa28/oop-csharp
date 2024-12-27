using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.ConsoleApp;

public class ConsoleWriter : IConsoleWriter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}