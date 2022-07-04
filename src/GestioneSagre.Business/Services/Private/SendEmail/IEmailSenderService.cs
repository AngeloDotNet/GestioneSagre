namespace GestioneSagre.Business.Services.Private.SendEmail;

public interface IEmailSenderService
{
    Task SendEmailSupportAsync(InputMailSender model);
}
