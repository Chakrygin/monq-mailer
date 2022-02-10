using Microsoft.EntityFrameworkCore;

namespace Monq.Mailer.DataAccess;

public sealed class MailContext : DbContext
{
    public MailContext(DbContextOptions<MailContext> options) :
        base(options)
    { }

    public DbSet<DbMail> Mails => Set<DbMail>();
}
