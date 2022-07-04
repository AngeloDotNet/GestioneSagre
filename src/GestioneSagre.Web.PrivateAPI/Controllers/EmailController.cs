namespace GestioneSagre.Web.PrivateAPI.Controllers;

public class EmailController : BaseController
{
    private readonly ILogger<EmailController> logger;
    private readonly IEmailSenderService emailService;

    public EmailController(ILogger<EmailController> logger, IEmailSenderService emailService)
    {
        this.logger = logger;
        this.emailService = emailService;
    }

    /// <summary>
    /// Servizio di invio email
    /// </summary>
    /// <response code="200">Email inviata con successo</response>
    /// <response code="400">Email non inviata causa errori</response>
    [AllowAnonymous]
    [HttpPost("InvioEmail")]
    [ProducesResponseType(typeof(InputMailSender), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InvioEmail(InputMailSender model)
    {
        try
        {
            await emailService.SendEmailSupportAsync(model);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
