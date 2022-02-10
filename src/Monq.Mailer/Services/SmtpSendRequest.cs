namespace Monq.Mailer.Services;

public sealed class SmtpSendRequest
{
    public string Subject { get; set; } = "";

    public string Body { get; set; } = "";

    public List<string> Recipients { get; init; } = null!;
}