using System.Net.Mail;
using System.Net.Mime;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Monq.Mailer.Contracts;
using Monq.Mailer.DataAccess;
using Monq.Mailer.Services;

namespace Monq.Mailer.Controllers;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public sealed class MailController : ControllerBase
{
    private readonly MailContext _context;

    public MailController(MailContext context)
    {
        _context = context;
    }

    [HttpPost("api/mails")]
    public async Task<SendMailResponse> SendMail(
        [FromBody] SendMailRequest request,
        [FromServices] SmtpSendService smtpSendService,
        CancellationToken cancellationToken)
    {
        var smtpSendRequest = new SmtpSendRequest
        {
            Subject = request.Subject,
            Body = request.Body,
            Recipients = request.Recipients,
        };

        var smtpSendResult = await smtpSendService.SmtpSendAsync(smtpSendRequest, cancellationToken);

        var mail = new DbMail
        {
            Id = Guid.NewGuid(),
            Subject = request.Subject,
            Body = request.Body,
            Recipients = request.Recipients,
            Result = smtpSendResult.Success,
            CreatedAt = DateTime.UtcNow,
            FailedMessage = smtpSendResult.ExceptionMessage,
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
