using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Recipient;

public class DisplayRecipient : IRecipient
{
    private readonly IDisplayDriver _driver;

    public string? Name { get; }

    public int ImportanceFilter { get; set; }

    public DisplayRecipient(string? name, IDisplayDriver driver)
    {
        Name = name;
        _driver = driver;
    }

    public void ReceiveMessage(IMessage? message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (message.ImportanceLevel >= ImportanceFilter)
        {
            _driver.Clear();
            _driver.WriteText(message.Body);
        }
    }
}
