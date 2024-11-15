namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface IDisplayDriver
{
    void Clear();

    void SetColor(string? color);

    void WriteText(string? text);
}
