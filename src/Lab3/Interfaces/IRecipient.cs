namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IRecipient
{
    string? Name { get; }

    int ImportanceFilter { get; set; }

    void ReceiveMessage(IMessage? message);
}