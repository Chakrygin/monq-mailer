namespace Monq.Mailer.Services;

/// <summary>
/// Запрос на отправку писема по smtp.
/// </summary>
public sealed class SmtpSendRequest
{
    /// <summary>
    /// Тема письма.
    /// </summary>
    public string Subject { get; set; } = "";

    /// <summary>
    /// Тело письма.
    /// </summary>
    public string Body { get; set; } = "";

    /// <summary>
    /// Список получателей.
    /// </summary>
    public List<string> Recipients { get; init; } = null!;
}
