using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Message;

public class MessageDevice : IMessage
{
    public string? Title { get; }

    public string? Body { get; }

    public int ImportanceLevel { get; }

    public MessageDevice(string? title, string? body, int importanceLevel)
    {
        Title = title;
        Body = body;
        ImportanceLevel = importanceLevel;
    }

    public bool Equals(IMessage? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Title == other.Title && Body == other.Body && ImportanceLevel == other.ImportanceLevel;
    }

    public override bool Equals(object? obj) => Equals(obj as IMessage);

    public override int GetHashCode() => HashCode.Combine(Title, Body, ImportanceLevel);
}
