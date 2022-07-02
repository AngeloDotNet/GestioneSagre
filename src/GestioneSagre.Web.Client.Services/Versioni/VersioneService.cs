namespace GestioneSagre.Web.Client.Services.Versioni;

public class VersioneService : IVersioneService
{
    private HttpClient httpClient;

    private string Versione = Configuration.versione;
    private string PrivateAPI = Configuration.privateAPI;

    public VersioneViewModel testoVersione { get; set; }

    public VersioneService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<VersioneViewModel> GetVersione()
    {
        testoVersione = await httpClient.GetFromJsonAsync<VersioneViewModel>($"{PrivateAPI}/api/versione/{Versione}");

        return testoVersione;
    }
}
