namespace Monq.Mailer.Contracts;

public sealed class MailModel
{
    /// <summary>
    /// Идентификатор письма.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Тема письма.
    /// </summary>
    public string Subject { get; set; } = "";

    /// <summary>
    /// Тело письма.
    /// </summary>
    public string Body { get; set; } = "";

    /// <summary>
    /// Список получаетелей письма.
    /// </summary>
    public List<string> Recipients { get; set; } = null!;

    /// <summary>
    /// Дата отправки.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Результат отправки письма.
    /// </summary>
    public MailResult Result { get; set; }

    /// <summary>
    /// Сообщение об ошибке в случае неуспешной отправки письма.
    /// </summary>
    public string? FailedMessage { get; set; }
}
