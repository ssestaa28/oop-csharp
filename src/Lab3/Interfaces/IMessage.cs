namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IMessage : IEquatable<IMessage>
{
    string? Title { get; }

    string? Body { get; }

    int ImportanceLevel { get; }
}
