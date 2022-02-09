using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Monq.Mailer.DataAccess;

namespace Monq.Mailer.Tests;

[TestClass]
public sealed class TestAssembly : TestClassBase
{
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext _)
    {
        using var scope = App.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<MailContext>();
        context.Database.Migrate();
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    { }
}
