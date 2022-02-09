using Monq.Mailer.Contracts;

using RestEase;

namespace Monq.Mailer.Client;

public interface IMailerClient
{
    [Post("api/mails")]
    Task<SendMailResponse> SendMailAsync(
        [Body] SendMailRequest request,
        CancellationToken cancellationToken = default);

    [Get("api/mails")]
    Task<GetMailsResponse> GetMailsAsync(
        CancellationToken cancellationToken = default);
}
