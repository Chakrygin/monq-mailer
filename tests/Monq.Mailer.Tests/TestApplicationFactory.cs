using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Monq.Mailer.Tests;

public class TestApplicationFactory : WebApplicationFactory<Startup>
{
    protected override IWebHostBuilder? CreateWebHostBuilder()
    {
        var builder = new WebHostBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.json");
            })
            .UseEnvironment("Testing")
            .UseStartup<Startup>();

        return builder;
    }
}
