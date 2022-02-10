using System.ComponentModel.DataAnnotations;

namespace Monq.Mailer.Contracts;

/// <summary>
/// Запрос на отправку письма.
/// </summary>
public sealed class SendMailRequest
{
    /// <summary>
    /// Тело письма.
    /// </summary>
    [Required]
    public string Subject { get; set; }

    /// <summary>
    /// Тело письма.
    /// </summary>
    [Required]
    public string Body { get; set; }

    /// <summary>
    /// Список получаетелей.
    /// </summary>
    [Required]
    public List<string> Recipients { get; set; }
}
