using System.Net.Mail;

using Microsoft.Extensions.Options;

namespace Monq.Mailer.Services;

/// <summary>
/// Сервис для отправки писем по smtp.
/// </summary>
public sealed class SmtpSendService
{
    private readonly IOptions<SmtpOptions> _options;

    public SmtpSendService(IOptions<SmtpOptions> options)
    {
        _options = options;
    }

    public async ValueTask<SmtpSendResult> SmtpSendAsync(SmtpSendRequest request, CancellationToken cancellationToken)
    {
        Exception? exception = null;

        try
        {
            using var smtp = new SmtpClient(_options.Value.Host, _options.Value.Port);

            var message = CreateMessage(request);
            await smtp.SendMailAsync(message, cancellationToken);
        }
        catch (OperationCanceledException ex)
            when (ex.CancellationToken == cancellationToken)
        {
            throw;
        }
        catch (Exception ex)
        {
            exception = ex;
        }

        var result = new SmtpSendResult
        {
            Success = exception == null,
            ExceptionMessage = exception?.Message,
        };

        return result;
    }

    private MailMessage CreateMessage(SmtpSendRequest request)
    {
        var message = new MailMessage();

        message.From = new MailAddress(
            _options.Value.FromAddress,
            _options.Value.FromName);

        message.Subject = request.Subject;
        message.Body = request.Body;

        foreach (var recipient in request.Recipients)
        {
            message.To.Add(recipient);
        }

        return message;
    }
}
