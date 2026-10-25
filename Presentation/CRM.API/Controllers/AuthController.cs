using Azure.Core;
using CRM.Application.Interfaces;
using CRM.Application.Requests;
using CRM.Application.Responses;
using CRM.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginRequest request) => await _authService.LoginAsync(request);

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegisterResponse>> RegisterAsync([FromBody] RegisterRequest request) => await _authService.RegisterAsync(request);









    }
}
