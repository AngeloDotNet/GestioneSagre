namespace GestioneSagre.Web.Server.Controllers;

public class FestaController : BaseController
{
    private readonly IFestaService festaService;
    public FestaController(IFestaService festaService)
    {
        this.festaService = festaService;
    }

    /// <summary>
    /// Mostra l'elenco delle feste
    /// </summary>
    /// <response code="200">Lista delle feste caricata con successo</response>
    /// <response code="400">Lista delle feste non caricata causa errori</response>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetElencoFesteAsync()
    {
        try
        {
            ListViewModel<FestaViewModel> feste = await festaService.GetFesteAsync();

            FestaListViewModel viewModel = new()
            {
                Feste = feste
            };

            return Ok(viewModel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Permette la creazione di una nuova festa
    /// </summary>
    /// <response code="200">Creazione di una nuova festa terminata con successo</response>
    /// <response code="400">Creazione di una nuova festa non terminata causa errori</response>
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(FestaCreateInputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateFesta([FromBody] FestaCreateInputModel inputModel)
    {
        try
        {
            FestaDetailViewModel festa = await festaService.CreateFestaAsync(inputModel);

            return Ok(festa);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Mostra il dettaglio di una festa specifica, richiamata via guid
    /// </summary>
    /// <response code="200">Dettaglio della festa caricato con successo</response>
    /// <response code="400">Dettaglio della festa non caricato causa errori</response>
    [AllowAnonymous]
    [HttpGet("{guidFesta}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ShowFesta(string guidFesta)
    {
        try
        {
            FestaDetailViewModel viewModel = await festaService.GetFestaAsync(guidFesta);

            return Ok(viewModel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Permette la modifica di una nuova festa
    /// </summary>
    /// <response code="200">Modifica della festa terminata con successo</response>
    /// <response code="400">Modifica della festa non terminata causa errori</response>
    [AllowAnonymous]
    [HttpPut]
    [ProducesResponseType(typeof(FestaEditInputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ModifyFesta([FromBody] FestaEditInputModel inputModel)
    {
        try
        {
            FestaDetailViewModel viewModel = await festaService.EditFestaAsync(inputModel);

            return Ok(viewModel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Permette la cancellazione di una nuova festa
    /// </summary>
    /// <response code="200">Cancellazione della festa terminata con successo</response>
    /// <response code="400">Cancellazione della festa non terminata causa errori</response>
    [AllowAnonymous]
    [HttpDelete]
    [ProducesResponseType(typeof(FestaDeleteInputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteFesta([FromBody] FestaDeleteInputModel inputModel)
    {
        try
        {
            await festaService.DeleteFestaAsync(inputModel);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}