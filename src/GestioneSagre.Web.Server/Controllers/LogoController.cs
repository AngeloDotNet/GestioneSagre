using GestioneSagre.Business.Services.Application.Logo;

namespace GestioneSagre.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogoController : ControllerBase
{
    private readonly ILogoService logoService;
    public LogoController(ILogoService logoService)
    {
        this.logoService = logoService;
    }

    [AllowAnonymous]
    [HttpPut]
    public async Task<IActionResult> EditLogo([FromForm] LogoEditInputModel inputModel)
    {
        try
        {
            await logoService.UploadLogoAsync(inputModel);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}