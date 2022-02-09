using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Monq.Mailer.DataAccess;

public sealed class MailContext : DbContext
{
    public MailContext(DbContextOptions<MailContext> options) :
        base(options)
    { }

    public DbSet<DbMail> Mails => Set<DbMail>();
}
