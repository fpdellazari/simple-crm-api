﻿using SimpleCRM.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Domain.Services.Authentication;

namespace SimpleCRM.API.Controllers {
    public class AuthenticationController : Controller {

        public readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService) {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("api/[controller]/authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticationModel authenticationModel) {
            try {
                var token = await _authenticationService.Authenticate(authenticationModel);
                if (token == "") {
                    return Unauthorized();
                }
                return Ok(new { token = token });
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }
    }
}
