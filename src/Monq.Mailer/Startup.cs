using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore;

using Monq.Mailer.DataAccess;
using Monq.Mailer.Services;

namespace Monq.Mailer;

public sealed class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("Mail");

        services.AddDbContext<MailContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddSingleton<SmtpSendService>();
        services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));

        services.AddSwaggerGen();

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                var converter = new JsonStringEnumConverter();
                options.JsonSerializerOptions.Converters.Add(converter);
            });
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
