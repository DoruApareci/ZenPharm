namespace ZenPharm.BL.Implementations.Configs;

public class SendGridSettings
{
    public const string OptionKey = "SendGridConfig";

    public string ApiKey { get; init; } = null!;
    public string DefaultEmail { get; init; } = null!;
    public string FromName { get; init; } = null!;
}
