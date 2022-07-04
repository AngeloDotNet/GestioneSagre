namespace GestioneSagre.Models.InputModels.InvioEmail;

public class InputMailSender
{
    public string MittenteNominativo { get; set; }

    public string MittenteEmail { get; set; }

    public string Oggetto { get; set; }

    public string Messaggio { get; set; }
}