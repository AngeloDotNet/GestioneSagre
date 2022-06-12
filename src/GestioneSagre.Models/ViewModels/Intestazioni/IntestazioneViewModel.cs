namespace GestioneSagre.Models.ViewModels.Intestazioni;

public class IntestazioneViewModel
{
    public int Id { get; private set; }
    public int FestaId { get; private set; }
    public string Titolo { get; private set; }
    public string Edizione { get; private set; }
    public string Luogo { get; private set; }
    public string Logo { get; private set; }

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