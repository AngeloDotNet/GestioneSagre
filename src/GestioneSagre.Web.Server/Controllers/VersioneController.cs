using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestioneSagre.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VersioneController : ControllerBase
{
    private readonly IVersioneService versioneService;
    public VersioneController(IVersioneService versioneService)
    {
        this.versioneService = versioneService;
    }

    [AllowAnonymous]
    [HttpGet]
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

    [AllowAnonymous]
    [HttpGet("{codiceVersione:guid}")]
    public async Task<IActionResult> GetVersioneAsync(Guid codiceVersione)
    {
        try
        {
            string codice = codiceVersione.ToString();

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

    [AllowAnonymous]
    [HttpPost]
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

    [AllowAnonymous]
    [HttpDelete]
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