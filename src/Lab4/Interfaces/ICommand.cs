namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface ICommand
{
    string Name { get; }

    void Execute(string[] args);

    string[] Arguments { get; set; }
}
