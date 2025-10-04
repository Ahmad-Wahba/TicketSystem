using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketSystem.Core.Interfaces;
using TicketSystem.Core.Models;

namespace TicketSystem.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
        }

        public string CreateToken(object user)
        {
            var claims = new List<Claim>();

            // Add common claims based on the object type
            if (user is User appUser)
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, appUser.Id.ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, appUser.Email));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            }
            else if (user is ITTeam itMember)
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, itMember.Id.ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, itMember.Email));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            }

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}