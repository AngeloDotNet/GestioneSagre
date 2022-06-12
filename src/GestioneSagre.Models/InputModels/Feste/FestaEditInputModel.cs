namespace GestioneSagre.Models.InputModels.Feste;

public class FestaEditInputModel
{
    //FESTA
    public string DataInizio { get; set; }
    public string DataFine { get; set; }
    public string GuidFesta { get; set; }

    //INTESTAZIONE
    public string Titolo { get; set; }
    public string Edizione { get; set; }
    public string Luogo { get; set; }
}