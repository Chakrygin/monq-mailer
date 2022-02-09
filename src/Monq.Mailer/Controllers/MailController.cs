using System.Net.Mail;
using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Monq.Mailer.Contracts;
using Monq.Mailer.DataAccess;

namespace Monq.Mailer.Controllers;

[ApiController]
public sealed class MailController : ControllerBase
{
    private readonly MailContext _context;

    public MailController(MailContext context)
    {
        _context = context;
    }

    [HttpPost("api/mails")]
    public async Task<SendMailResponse> SendMail([FromBody] SendMailRequest request, CancellationToken cancellationToken)
    {
        Exception? exception = null;

        try
        {
            var message = new MailMessage();

            message.Subject = request.Subject;
            message.Body = request.Body;

            message.From = new MailAddress("test@mail.ru");

            foreach (var recipient in request.Recipients)
            {
                message.To.Add(recipient);
            }

            using var smtp = new SmtpClient("localhost", 2525);

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

        var mail = new DbMail
        {
            Id = Guid.NewGuid(),
            Subject = request.Subject,
            Body = request.Body,
            Recipients = request.Recipients,
            Result = exception == null,
            CreatedAt = DateTime.UtcNow,
            FailedMessage = exception?.Message,
        };

        _context.Mails.Add(mail);

        await _context.SaveChangesAsync(cancellationToken);

        var response = new SendMailResponse();
        response.MailId = mail.Id;

        return response;
    }

    [HttpGet("api/mails")]
    public async Task<GetMailsResponse> GetMails()
    {
        var mails = await _context.Mails
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        var response = new GetMailsResponse();
        response.Mails = mails
            .Select(mail => new MailModel
            {
                Id = mail.Id,
                Subject = mail.Subject,
                Body = mail.Body,
                Recipients = mail.Recipients,
                CreatedAt = mail.CreatedAt,
                Result = mail.Result ? MailResult.OK : MailResult.Failed,
                FailedMessage = mail.FailedMessage,
            })
            .ToList();

        return response;
    }
}
