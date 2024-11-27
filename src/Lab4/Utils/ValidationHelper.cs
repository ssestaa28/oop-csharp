namespace Itmo.ObjectOrientedProgramming.Lab4.Utils;

public class ValidationHelper
{
    public void ValidateNotEmpty(string? value, string parameterName)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(parameterName, $"{parameterName} не может быть нулевым или пустым");
        }
    }
}
