using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Recipient;

public class UserRecipient : IRecipient
{
    private readonly ICollection<IMessage> _messages = new HashSet<IMessage>();
    private readonly Dictionary<IMessage, bool> _messageStatus = new Dictionary<IMessage, bool>();
    private ILogger? _logger;

    public string? Name { get; }

    public int ImportanceFilter { get; set; }

    public IEnumerable<IMessage> Messages => _messages;

    public IReadOnlyDictionary<IMessage, bool> MessageStatus => new Dictionary<IMessage, bool>(_messageStatus);

    public UserRecipient(string? name)
    {
        Name = name;
    }

    public void SetLogger(ILogger logger)
    {
        _logger = logger;
    }

    public void ReceiveMessage(IMessage? message)
    {
        ArgumentNullException.ThrowIfNull(message);

        if (message.ImportanceLevel >= ImportanceFilter)
        {
            _messages.Add(message);
            _messageStatus[message] = false;

            _logger?.Log($"Message received: {message.Title}");
        }
    }

    public void MarkAsRead(IMessage? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (!_messageStatus.ContainsKey(message))
        {
            throw new InvalidOperationException("Сообщения нет (-_-)");
        }

        if (_messageStatus[message])
        {
            throw new InvalidOperationException("Сообщение прочитано (-_-)");
        }

        _messageStatus[message] = true;
    }
}
