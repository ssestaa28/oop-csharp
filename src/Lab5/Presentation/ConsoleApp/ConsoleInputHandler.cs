using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.ConsoleApp;

public class ConsoleInputHandler : IInputHandler
{
    public string GetUserInput(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine() ?? string.Empty;
    }
}
