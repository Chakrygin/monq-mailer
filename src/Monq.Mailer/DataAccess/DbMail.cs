using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Monq.Mailer.DataAccess;

[Table("mail")]
[Index(nameof(CreatedAt))]
public sealed class DbMail
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("subject")]
    public string Subject { get; set; } = "";

    [Column("body")]
    public string Body { get; set; }= "";

    [Column("recipients")]
    public List<string> Recipients { get; set; } = null!;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("result")]
    public bool Result { get; set; }

    [Column("failed_message")]
    public string? FailedMessage { get; set; }
}
