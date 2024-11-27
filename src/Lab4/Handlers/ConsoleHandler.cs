using Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ConsoleHandler : IConsoleHandler
{
    private readonly CommandProcessor _processor;
    private readonly AppConfig _config;

    public ConsoleHandler(CommandProcessor processor, AppConfig config)
    {
        _processor = processor ?? throw new ArgumentNullException(nameof(processor));
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public void Start()
    {
        Console.WriteLine(_config.WelcomeMessage);
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            try
            {
                HandleCommand(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public void HandleCommand(string? command)
    {
        if (string.IsNullOrEmpty(command))
        {
            throw new ArgumentNullException(nameof(command), "Команда не может быть нулевой или пустой");
        }

        _processor.Execute(command);
    }
}
