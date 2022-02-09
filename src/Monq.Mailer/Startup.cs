using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

using Monq.Mailer.DataAccess;

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
