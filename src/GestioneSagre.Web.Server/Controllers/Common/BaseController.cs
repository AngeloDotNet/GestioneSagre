using System.Net.Mime;

namespace GestioneSagre.Web.Server.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BaseController : ControllerBase
{

}
