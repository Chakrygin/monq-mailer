using System.ComponentModel.DataAnnotations.Schema;

namespace Monq.Mailer.DataAccess;

[Table("mail")]
public sealed class DbMail
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("subject")]
    public string Subject { get; set; }

    [Column("body")]
    public string Body { get; set; }

    [Column("recipients")]
    public List<string> Recipients { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("result")]
    public bool Result { get; set; }

    [Column("failed_message")]
    public string? FailedMessage { get; set; }
}
