namespace GestioneSagre.Business.Services.Private.SendEmail;

public class MailKitEmailSender : IEmailSenderService
{
    private readonly IOptionsMonitor<SmtpOptions> smtpOptionsMonitor;
    private readonly ILogger<MailKitEmailSender> logger;

    public MailKitEmailSender(IOptionsMonitor<SmtpOptions> smtpOptionsMonitor, ILogger<MailKitEmailSender> logger)
    {
        this.logger = logger;
        this.smtpOptionsMonitor = smtpOptionsMonitor;
    }

    public async Task SendEmailAsync(InputMailSender model)
    {
        try
        {
            var options = this.smtpOptionsMonitor.CurrentValue;

            using SmtpClient client = new();

            await client.ConnectAsync(options.Host, options.Port, options.Security);

            if (!string.IsNullOrEmpty(options.Username))
            {
                await client.AuthenticateAsync(options.Username, options.Password);
            }

            MimeMessage message = new();

            message.From.Add(MailboxAddress.Parse(options.Sender));
            message.To.Add(MailboxAddress.Parse(model.recipientEmail));
            message.Subject = model.subject;

            var builder = new BodyBuilder();

            //if (model.attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in model.attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }

            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}

            builder.HtmlBody = model.htmlMessage;
            message.Body = builder.ToMessageBody();

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch
        {
            throw new Exception();
        }
    }
}
