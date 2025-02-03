using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpleCRM.Domain.Models;
using SimpleCRM.Domain.Services.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Application.Services.Authentication {
    public class AuthenticationService : IAuthenticationService {

        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IConfiguration configuration, ITokenService tokenService) {
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public async Task<string> Authenticate(AuthenticationModel authentication) {
            if (authentication.Username != "admin" || authentication.Password != "123456") return "";
            var token = _tokenService.Generate(authentication.Username);
            return token;
        }
    }
}
