namespace GestioneSagre.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FestaController : ControllerBase
{
    private readonly IFestaService festaService;
    public FestaController(IFestaService festaService)
    {
        this.festaService = festaService;
    }

    [AllowAnonymous]
    [HttpGet]
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

    [AllowAnonymous]
    [HttpPost]
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

    [AllowAnonymous]
    [HttpGet("{guidFesta}")]
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

    [AllowAnonymous]
    [HttpPut]
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

    [AllowAnonymous]
    [HttpDelete]
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