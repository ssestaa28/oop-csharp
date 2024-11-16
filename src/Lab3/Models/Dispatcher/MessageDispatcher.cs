using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Dispatcher;

public class MessageDispatcher : IMessageDispatcher
{
    public void DispatchMessage(IMessage? message, IEnumerable<IRecipient>? recipients)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(recipients);

        foreach (IRecipient recipient in recipients)
        {
            recipient?.ReceiveMessage(message);
        }
    }
}