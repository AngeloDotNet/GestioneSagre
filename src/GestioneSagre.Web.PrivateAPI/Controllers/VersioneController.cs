﻿namespace GestioneSagre.Web.PrivateAPI.Controllers;

public class VersioneController : BaseController
{
    private readonly IVersioneServicePrivate versioneService;
    public VersioneController(IVersioneServicePrivate versioneService)
    {
        this.versioneService = versioneService;
    }

    /// <summary>
    /// Mostra l'elenco delle versioni software
    /// </summary>
    /// <response code="200">Lista delle versioni software caricato con successo</response>
    /// <response code="400">Lista delle versioni software non caricato causa errori</response>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetElencoFesteAsync()
    {
        try
        {
            ListViewModel<VersioneViewModel> versione = await versioneService.GetVersioniAsync();

            VersioneListViewModel viewModel = new()
            {
                Versioni = versione
            };

            return Ok(viewModel);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Mostra i dettagli di una specifica versione software
    /// </summary>
    /// <response code="200">Dettaglio della versione software caricato con successo</response>
    /// <response code="400">Dettaglio della versione software non caricato causa errori</response>
    [AllowAnonymous]
    [HttpGet("{codiceVersione:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetVersioneAsync(Guid codiceVersione)
    {
        try
        {
            var codice = codiceVersione.ToString();

            VersioneViewModel versione = await versioneService.GetVersioneAsync(codice);

            if (versione == null)
            {
                return NotFound();
            }

            return Ok(versione);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Permette di creare una nuova versione software
    /// </summary>
    /// <response code="200">Creazione nuova versione software creata con successo</response>
    /// <response code="400">Creazione nuova versione software non creata causa errori</response>
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(VersioneCreateInputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateVersioneAsync([FromBody] VersioneCreateInputModel inputModel)
    {
        try
        {
            bool bRes = await versioneService.IsVersioneAvailableAsync(inputModel.TestoVersione, 0);

            if (!bRes)
            {
                return BadRequest("Versione già presente");
            }
            else
            {
                VersioneDetailViewModel versione = await versioneService.CreateVersioneAsync(inputModel);
                return Ok(versione);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Permette di cancellare una nuova versione software
    /// </summary>
    /// <response code="200">Versione software cancellata con successo</response>
    /// <response code="400">Versione software non cancellata causa errori</response>
    [AllowAnonymous]
    [HttpDelete]
    [ProducesResponseType(typeof(VersioneDeleteInputModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteVersioneAsync([FromBody] VersioneDeleteInputModel inputModel)
    {
        try
        {
            await versioneService.DeleteVersioneAsync(inputModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}