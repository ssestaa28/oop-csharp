namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

internal interface IRecipientLogger
{
    void LogRecipientMessage(IRecipient? recipient, IMessage? message);
}
