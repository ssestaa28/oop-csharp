using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Recipient;

public class MessengerRecipient : IRecipient
{
    private readonly IMessenger _messenger;

    public string? Name { get; }

    public int ImportanceFilter { get; set; }

    public MessengerRecipient(string? name, IMessenger messenger)
    {
        Name = name;
        _messenger = messenger;
    }

    public void ReceiveMessage(IMessage? message)
    {
        ArgumentNullException.ThrowIfNull(message);

        if (message.ImportanceLevel >= ImportanceFilter)
        {
            _messenger.SendMessage(message.Body ?? string.Empty);
        }
    }
}
