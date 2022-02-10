namespace Monq.Mailer.Contracts;

/// <summary>
/// Результат отправки письма.
/// </summary>
public enum MailResult
{
    /// <summary>
    /// Успех.
    /// </summary>
    OK,

    /// <summary>
    /// Ошибка.
    /// </summary>
    Failed,
}
