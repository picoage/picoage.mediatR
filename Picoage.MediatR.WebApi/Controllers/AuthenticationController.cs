using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Picoage.MediatR.Application.Interfaces.Services;
using Picoage.MediatR.Application.RequestModels;

namespace Picoage.MediatR.WebApi.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api-token")]
        public async Task<IActionResult> GetAuthenticationToken([FromBody]AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest?.Username) || string.IsNullOrEmpty(authenticationRequest.Password))
                return BadRequest(error: "Invalid user name or password");

            return Ok(await authenticationService.Authenticate(authenticationRequest.Username, authenticationRequest.Password));
        }
    }
}