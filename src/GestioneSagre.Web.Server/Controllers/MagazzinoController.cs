namespace GestioneSagre.Web.Server.Controllers;

public class MagazzinoController : BaseController
{
    private readonly ICategorieService categorieService;
    private readonly IProdottiService prodottiService;
    public MagazzinoController(ICategorieService categorieService, IProdottiService prodottiService)
    {
        this.categorieService = categorieService;
        this.prodottiService = prodottiService;
    }

    #region "CATEGORIE"
    //GetElencoCategorieAsync

    //CreateCategoriaAsync

    //EditCategoriaAsync

    //DeleteCategoriaAsync (solo se alla categoria non vi sono associati prodotti)
    #endregion

    #region "PRODOTTI"
    //GetElencoProdottiAsync

    //CreateProdottoAsync

    //EditProdottoAsync

    //DeleteProdottoAsync (valutare se implementare questa funzione)
    #endregion
}
