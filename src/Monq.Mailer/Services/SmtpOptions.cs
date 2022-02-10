namespace Monq.Mailer.Services;

public sealed class SmtpOptions
{
    public string Host { get; set; } = "";

    public int Port { get; set; }

    public string FromAddress { get; set; } = "";

    public string FromName { get; set; } = "";
}
