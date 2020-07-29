using Picoage.MediatR.Application.Models.ResposeModels;
using System.Threading.Tasks;

namespace Picoage.MediatR.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(string userName, string Password); 
    }
}
