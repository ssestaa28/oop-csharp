using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models.Drivers;

public class DisplayDriver : IDisplayDriver
{
    public void Clear()
    {
        Console.WriteLine("Clearing display...");
    }

    public void SetColor(string? color)
    {
        ArgumentNullException.ThrowIfNull(color);
    }

    public void WriteText(string? text)
    {
        ArgumentNullException.ThrowIfNull(text);
        Console.WriteLine($"Display: {text}");
    }
}
