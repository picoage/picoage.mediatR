namespace Picoage.MediatR.Application.RequestModels
{
    public class AuthenticationRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
