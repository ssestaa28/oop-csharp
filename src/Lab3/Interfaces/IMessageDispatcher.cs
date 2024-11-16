namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IMessageDispatcher
{
    void DispatchMessage(IMessage? message, IEnumerable<IRecipient>? recipients);
}
