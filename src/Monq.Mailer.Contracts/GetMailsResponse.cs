namespace Monq.Mailer.Contracts;

/// <summary>
/// Ответ на запрос получения списка оправленных писем.
/// </summary>
public sealed class GetMailsResponse
{
    /// <summary>
    /// Список писем.
    /// </summary>
    public List<MailModel> Mails { get; set; }
}
