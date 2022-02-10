namespace Monq.Mailer.Services;

/// <summary>
/// Результат отправки письма по smtp.
/// </summary>
public sealed class SmtpSendResult
{
    /// <summary>
    /// Успешность отправки письма.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Сообщение об ошибке при неуспешной отправки письма.
    /// </summary>
    public string? ExceptionMessage { get; set; }
}
