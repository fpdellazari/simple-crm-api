using SimpleCRM.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Domain.Services.Authentication;

namespace SimpleCRM.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller {

        public readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticationModel authenticationModel) {
            try {
                var token = await _authenticationService.Authenticate(authenticationModel);
                if (token == "") {
                    return Unauthorized(new { Message = "Usuário ou senha inválidos." });
                }
                return Ok(new { Message = "Token gerado com sucesso.", Token = token });
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Erro interno no servidor.", Details = e.Message });
            }
        }
    }
}
