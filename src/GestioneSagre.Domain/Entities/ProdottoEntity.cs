namespace GestioneSagre.Domain.Entities;

public class ProdottoEntity
{
    public int Id { get; private set; }
    public int CategoriaId { get; private set; }
    public string Prodotto { get; private set; }
    public bool ProdottoAttivo { get; private set; }
    public Money Prezzo { get; private set; }
    public int Quantita { get; private set; }
    public bool QuantitaAttiva { get; private set; }
    public int QuantitaScorta { get; private set; }
    public bool AvvisoScorta { get; private set; }
    public bool Prenotazione { get; private set; }
    public virtual CategoriaEntity Categoria { get; set; }

    public void ChangeCategoriaId(int categoriaId)
    {
        CategoriaId = categoriaId;
    }

    public void ChangeProdotto(string prodotto)
    {
        Prodotto = prodotto;
    }

    public void ChangeProdottoAttivo(bool prodottoAttivo)
    {
        ProdottoAttivo = prodottoAttivo;
    }

    public void ChangePrezzo(Money prezzo)
    {
        Prezzo = prezzo;
    }

    public void ChangeQuantita(int quantita)
    {
        Quantita = quantita;
    }

    public void ChangeQuantitaAttiva(bool quantitaAttiva)
    {
        QuantitaAttiva = quantitaAttiva;
    }

    public void ChangeQuantitaScorta(int quantitaScorta)
    {
        QuantitaScorta = quantitaScorta;
    }

    public void ChangeAvvisoScorta(bool avvisoScorta)
    {
        AvvisoScorta = avvisoScorta;
    }

    public void ChangePrenotazione(bool prenotazione)
    {
        Prenotazione = prenotazione;
    }
}
