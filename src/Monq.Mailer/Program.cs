using Microsoft.EntityFrameworkCore;

using Monq.Mailer.DataAccess;

namespace Monq.Mailer;

public static class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStartup<Startup>();
            })
            .Build();

        host.Migrate<MailContext>();
        host.Run();
    }

    private static void Migrate<TContext>(this IHost host)
        where TContext : DbContext
    {
        using var scope = host.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        context.Database.Migrate();
    }
}
