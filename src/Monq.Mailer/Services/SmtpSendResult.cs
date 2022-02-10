namespace Monq.Mailer.Services;

public sealed class SmtpSendResult
{
    public bool Success { get; set; }

    public string? ExceptionMessage { get; set; }
}