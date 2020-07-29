using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Picoage.MediatR.Application.AppSettings;
using Picoage.MediatR.Application.Interfaces.Repositories;
using Picoage.MediatR.Application.Interfaces.Services;
using Picoage.MediatR.Application.Models.ResposeModels;
using Picoage.MediatR.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Picoage.MediatR.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IOptions<AuthenticationSettings> authenticationConfiguration;

        public AuthenticationService(ICustomerRepository customerRepository, IOptions<AuthenticationSettings> authenticationConfiguration)
        {
            this.customerRepository = customerRepository;
            this.authenticationConfiguration = authenticationConfiguration; 
        }

        public async Task<AuthenticationResponse> Authenticate(string userName, string password)
        {
            IEnumerable<Customer> users = await customerRepository.GetAll();

            Customer user = users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            if (user == null) return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authenticationConfiguration.Value.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
               }),
                Expires = DateTime.UtcNow.AddDays(authenticationConfiguration.Value.Expire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            string tokenAsString = tokenHandler.WriteToken(token);

            return new AuthenticationResponse
            {
                UserName = user.UserName,
                Token = tokenAsString
            };
        }
    }
}
