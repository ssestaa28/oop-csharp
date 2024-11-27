using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class CommandProcessor
{
    private readonly Collection<Iёnterfaces.ICommand> _commands = new();

    public void RegisterCommand(Iёnterfaces.ICommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        _commands.Add(command);
    }

    public void Execute(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException(nameof(input), "Ввод команды не может быть нулевым или пустым");
        }

        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
        {
            throw new InvalidOperationException("Команда не предоставлена");
        }

        string commandName = parts[0];
        string[] args = parts.Skip(1).ToArray();

        Iёnterfaces.ICommand? command = _commands.FirstOrDefault(c => c.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));
        if (command is null)
        {
            throw new InvalidOperationException($"Command '{commandName}' not найдена");
        }

        command.Execute(args);
    }
}