namespace GestioneSagre.Web.Client.Services.Supporto;

public class SupportoService : ISupportoService
{
    private HttpClient httpClient;

    //private string Versione = Configuration.versione;
    private string PrivateAPI = Configuration.privateAPI;

    public SupportoService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task InvioEmailSupporto(InputMailSender inputModel)
    {
        var response = await httpClient.PostAsJsonAsync($"{PrivateAPI}/api/Email/InvioEmail", inputModel);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Richiesta di supporto non inviata a causa di un problema tecnico.");
        }
    }
}