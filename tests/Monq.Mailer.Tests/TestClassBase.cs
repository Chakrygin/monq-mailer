using Monq.Mailer.Client;

using RestEase;

namespace Monq.Mailer.Tests;

public abstract class TestClassBase
{
    public static TestApplicationFactory App { get; } = new();

    public static IMailerClient Client { get; } = CreateClient();

    private static IMailerClient CreateClient()
    {
        var httpClient = App.CreateClient();
        var restClient = RestClient.For<IMailerClient>(httpClient);

        return restClient;
    }
}
