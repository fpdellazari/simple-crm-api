using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpleCRM.Domain.Services.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Application.Services.Authentication {
    public class TokenService : ITokenService {

        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string Generate(string userName) {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:PrivateKey"]);
            var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = GenerateClaims(userName),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(string userName) {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, userName));
            ci.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            return ci;
        }
    }
}
