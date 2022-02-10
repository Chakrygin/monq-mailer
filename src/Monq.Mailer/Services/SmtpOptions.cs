namespace Monq.Mailer.Services;

/// <summary>
/// Настройки для отправки писем по SMTP.
/// </summary>
public sealed class SmtpOptions
{
    /// <summary>
    /// Хост smtp-сервера.
    /// </summary>
    public string Host { get; set; } = "";

    /// <summary>
    /// Порт smtp-сервера.
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Адрес отправителя для всех писем.
    /// </summary>
    public string FromAddress { get; set; } = "";

    /// <summary>
    /// Имя отправителя для всех писем.
    /// </summary>
    public string FromName { get; set; } = "";
}
