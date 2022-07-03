namespace GestioneSagre.Models.InputModels.InvioEmail;

public class InputMailSender
{
    public string recipientEmail { get; set; }

    public string subject { get; set; }

    public string htmlMessage { get; set; }

    //public List<IFormFile> attachments { get; set; }
}