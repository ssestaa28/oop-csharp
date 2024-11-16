namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IRecipientFilter
{
    bool IsMessageAllowed(IMessage? message, IRecipient? recipient);
}
