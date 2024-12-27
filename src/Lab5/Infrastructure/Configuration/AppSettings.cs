namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Configuration;

public class AppSettings
{
    public string? ConnectionString { get; set; }

    public string? AdminPassword { get; set; }

    public LoggingSettings? Logging { get; set; }

    public ApiSettings? Api { get; set; }
}
