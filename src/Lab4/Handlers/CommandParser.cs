using Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class CommandParser
{
    private readonly IEnumerable<ICommand> _availableCommands;

    public CommandParser(IEnumerable<ICommand> availableCommands)
    {
        _availableCommands = availableCommands ?? throw new ArgumentNullException(nameof(availableCommands));
    }

    public ICommand Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException("Input cannot be null or пустым", nameof(input));
        }

        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string commandName = string.Join(" ", parts.Take(2));
        string[] args = parts.Skip(2).ToArray();

        ICommand? command = _availableCommands.FirstOrDefault(c => string.Equals(c.Name, commandName, StringComparison.OrdinalIgnoreCase));

        if (command == null)
        {
            throw new InvalidOperationException($"Неизвестная command: {commandName}");
        }

        command.Arguments = args;
        return command;
    }
}