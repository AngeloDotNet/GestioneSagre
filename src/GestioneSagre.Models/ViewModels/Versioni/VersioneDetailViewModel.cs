namespace GestioneSagre.Models.ViewModels.Versioni;

public class VersioneDetailViewModel : BaseViewModel
{
    //public int Id { get; set; }
    public string CodiceVersione { get; set; } = string.Empty;
    public string TestoVersione { get; set; } = string.Empty;
    public VersioneStato VersioneStato { get; set; }

    public static VersioneDetailViewModel FromEntity(VersioneEntity versione)
    {
        return new VersioneDetailViewModel
        {
            Id = versione.Id,
            CodiceVersione = versione.CodiceVersione,
            TestoVersione = versione.TestoVersione,
            VersioneStato = versione.VersioneStato
        };
    }
}
