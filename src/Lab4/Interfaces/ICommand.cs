namespace Itmo.ObjectOrientedProgramming.Lab4.Iёnterfaces;

public interface ICommand
{
    string Name { get; }

    void Execute(string[] args);

    string[] Arguments { get; set; }
}
