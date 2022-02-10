namespace Monq.Mailer.Contracts;

/// <summary>
/// Ответ на запрос отправки письма.
/// </summary>
public sealed class SendMailResponse
{
    /// <summary>
    /// Идентификатор письма.
    /// </summary>
    public Guid MailId { get; set; }
}
