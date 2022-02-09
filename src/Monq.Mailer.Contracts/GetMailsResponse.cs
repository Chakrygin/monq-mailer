namespace Monq.Mailer.Contracts;

public sealed class GetMailsResponse
{
    public List<MailModel> Mails { get; set; }
}
