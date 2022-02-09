namespace Monq.Mailer.Contracts;

public sealed class MailModel
{
    public Guid Id { get; set; }

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;

    public List<string> Recipients { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public MailResult Result { get; set; }

    public string? FailedMessage { get; set; }
}
