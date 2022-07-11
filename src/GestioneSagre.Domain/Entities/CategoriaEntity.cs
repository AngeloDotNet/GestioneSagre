namespace GestioneSagre.Domain.Entities;

public class CategoriaEntity
{
    public int Id { get; private set; }
    public string CategoriaVideo { get; private set; } = string.Empty;
    public string CategoriaStampa { get; private set; } = string.Empty;
    public virtual ICollection<ProdottoEntity> Prodotti { get; private set; }

    public void ChangeCategoriaVideo(string categoriaVideo)
    {
        CategoriaVideo = categoriaVideo;
    }

    public void ChangeCategoriaStampa(string categoriaStampa)
    {
        CategoriaStampa = categoriaStampa;
    }
}