namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.DTO;

public class LoginRequest
{
    public string AccountNumber { get; set; } = string.Empty;

    public string Pin { get; set; } = string.Empty;
}