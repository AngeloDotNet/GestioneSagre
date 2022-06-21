namespace GestioneSagre.Models.Entities;

public class IntestazioneEntity
{
    public int Id { get; private set; }
    public int FestaId { get; private set; }
    public string Titolo { get; private set; }
    public string Edizione { get; private set; }
    public string Luogo { get; private set; }
    public string Logo { get; private set; }
    public virtual FestaEntity Festa { get; set; }

    public void ChangeFestaId(int festaId)
    {
        FestaId = festaId;
    }

    public void ChangeTitolo(string titolo)
    {
        Titolo = titolo;
    }

    public void ChangeEdizione(string edizione)
    {
        Edizione = edizione;
    }

    public void ChangeLuogo(string luogo)
    {
        Luogo = luogo;
    }

    public void ChangeLogo(string logo)
    {
        Logo = logo;
    }
}
