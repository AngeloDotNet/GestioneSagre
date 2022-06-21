using GestioneSagre.Domain.Enums;

namespace GestioneSagre.Domain.Entities;

public class FestaEntity
{
    public int Id { get; private set; }
    public string DataInizio { get; private set; }
    public string DataFine { get; private set; }
    public string GuidFesta { get; private set; }
    public FestaStato StatusFesta { get; private set; }
    public virtual ICollection<IntestazioneEntity> Intestazioni { get; private set; }

    public void ChangeDataInizio(string dataInizio)
    {
        DataInizio = dataInizio;
    }

    public void ChangeDataFine(string dataFine)
    {
        DataFine = dataFine;
    }

    public void ChangeGuidFesta(string guidFesta)
    {
        GuidFesta = guidFesta;
    }

    public void ChangeStatusFesta(FestaStato statusFesta)
    {
        StatusFesta = statusFesta;
    }
}