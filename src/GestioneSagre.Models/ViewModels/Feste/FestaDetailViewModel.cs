namespace GestioneSagre.Models.ViewModels.Feste;

public class FestaDetailViewModel
{
    public int Id { get; set; }
    public string DataInizio { get; set; }
    public string DataFine { get; set; }
    public string GuidFesta { get; set; }
    public FestaStato StatusFesta { get; set; }

    public List<IntestazioneViewModel> Intestazioni { get; set; } = new List<IntestazioneViewModel>();

    public static FestaDetailViewModel FromEntity(FestaEntity festa)
    {
        return new FestaDetailViewModel
        {
            Id = festa.Id,
            DataInizio = festa.DataInizio,
            DataFine = festa.DataFine,
            GuidFesta = festa.GuidFesta,
            StatusFesta = festa.StatusFesta,
            Intestazioni = festa.Intestazioni
                .OrderBy(intestazione => intestazione.Id)
                .ThenBy(lesson => lesson.Id)
                .Select(intestazione => IntestazioneViewModel.FromEntity(intestazione))
                .ToList()
        };
    }
}