using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;

using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private API.Extensions.LoggingExtensions _Logger = null;
        
        public TokenService(IConfiguration config)
        {
            Console.WriteLine(" TokenService - Constructor") ; 
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _Logger = new API.Extensions.LoggingExtensions();
        }

        public string CreateToken(AppUser user)
        {
            
            Console.WriteLine(" TokenService - CreateToken - start") ; 
            var claims = new List<Claim>
            { new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            var creds =  new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                    Subject =  new System.Security.Claims.ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = creds
            };

            Console.WriteLine(" TokenService - CreateToken - return - tokenDescriptor: " + tokenDescriptor.ToString() ) ; 
            var tokenHandler = new JwtSecurityTokenHandler();

            var token =  tokenHandler.CreateToken(tokenDescriptor);

            Console.WriteLine(" TokenService - CreateToken - return - token: " + token.ToString() ) ; 
            return tokenHandler.WriteToken(token);
        }
    }
}