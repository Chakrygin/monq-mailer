using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Monq.Mailer.Contracts;

namespace Monq.Mailer.Tests;

[TestClass]
public sealed class TestClass : TestClassBase
{
    private const string TestSubject = "Hello, Subject!";
    private const string TestBody = "Hello, Body!";

    [TestMethod]
    [DataRow("igor@chakrygin.ru", true)]
    [DataRow("invalid_recipient", false)]
    public async Task SendMailTest(string recipient, bool success)
    {
        var sendMailRequest = new SendMailRequest
        {
            Subject = TestSubject,
            Body = TestBody,
            Recipients = new List<string>
            {
                recipient,
            }
        };

        var sendMailResponse = await Client.SendMailAsync(sendMailRequest);

        Print("SendMailResponse", sendMailResponse);

        var mailId = sendMailResponse.MailId;
        mailId.Should().NotBeEmpty();

        var getMailsResponse = await Client.GetMailsAsync();

        Print("GetMailsResponse", getMailsResponse);

        var mail = getMailsResponse.Mails.Single(x => x.Id == mailId);

        mail.Subject.Should().Be(TestSubject);
        mail.Body.Should().Be(TestBody);
        mail.Recipients.Should().Contain(recipient);
        mail.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromMinutes(1));

        if (success)
        {
            mail.Result.Should().Be(MailResult.OK);
            mail.FailedMessage.Should().BeNull();
        }
        else
        {
            mail.Result.Should().Be(MailResult.Failed);
            mail.FailedMessage.Should().NotBeEmpty();
        }
    }

    private static void Print<T>(string name, T value)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };
        var json = JsonSerializer.Serialize(value, typeof(T), options);

        Console.WriteLine(name + ": " + json);
        Console.WriteLine();
    }
}
