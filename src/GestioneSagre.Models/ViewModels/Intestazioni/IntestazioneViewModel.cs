namespace GestioneSagre.Models.ViewModels.Intestazioni;

public class IntestazioneViewModel : BaseViewModel
{
    //public int Id { get; set; }
    public int FestaId { get; set; }
    public string Titolo { get; set; }
    public string Edizione { get; set; }
    public string Luogo { get; set; }
    public string Logo { get; set; }

    public static IntestazioneViewModel FromEntity(IntestazioneEntity entity)
    {
        return new IntestazioneViewModel
        {
            Id = entity.Id,
            FestaId = entity.FestaId,
            Titolo = entity.Titolo,
            Edizione = entity.Edizione,
            Luogo = entity.Luogo,
            Logo = entity.Logo
        };
    }
}