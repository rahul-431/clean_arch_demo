using DinnerApp.Application.Services.Authentication;
using DinnerApp.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
namespace DinnerApp.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationControllers : ControllerBase
{

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationControllers(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.FirstName,
                authResult.Email,
                authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.Email, request.Password);
        var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.FirstName,
                authResult.Email,
                authResult.Token
        );
        return Ok(response);
    }

}