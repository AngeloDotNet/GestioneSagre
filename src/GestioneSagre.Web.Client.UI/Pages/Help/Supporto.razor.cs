namespace GestioneSagre.Web.Client.UI.Pages.Help;

public partial class Supporto
{
    private InputMailSender model = new()
    {
        MittenteNominativo = string.Empty,
        MittenteEmail = string.Empty,
        Oggetto = "Richiesta di supporto",
        Messaggio = string.Empty
    };

    private string typeAlert = string.Empty;
    private string textAlert = string.Empty;

    private async Task Submit()
    {
        try
        {
            await supportoService.InvioEmailSupporto(model);

            typeAlert = "confirm";
            textAlert = "Richiesta di supporto inviata con successo !";

            model = new()
            {
                MittenteNominativo = string.Empty,
                MittenteEmail = string.Empty,
                Oggetto = "Richiesta di supporto",
                Messaggio = string.Empty
            };
        }
        catch (Exception ex)
        {
            typeAlert = "error";
            textAlert = ex.Message;
        }
    }

    private void Cancel()
    {
        model = new();
    }
}