using System.ComponentModel.DataAnnotations;

namespace Monq.Mailer.Contracts;

public sealed class SendMailRequest
{
    [Required]
    public string Subject { get; set; }

    [Required]
    public string Body { get; set; }

    [Required]
    public List<string> Recipients { get; set; }
}
