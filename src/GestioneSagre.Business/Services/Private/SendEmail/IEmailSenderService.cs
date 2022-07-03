namespace GestioneSagre.Business.Services.Private.SendEmail;

public interface IEmailSenderService
{
    Task SendEmailAsync(InputMailSender model);
}
