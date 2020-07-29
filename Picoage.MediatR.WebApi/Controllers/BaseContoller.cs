using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Picoage.MediatR.WebApi.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    //[Authorize]
    public class BaseController:ControllerBase
    {
    }
}
