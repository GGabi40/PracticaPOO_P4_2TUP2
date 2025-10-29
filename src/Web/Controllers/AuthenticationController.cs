using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Interfaces;

namespace Web.Controllers;

[ApiController]
[Route("authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly ICustomAuthenticationService _customAuthenticationService;

    public AuthenticationController(IConfiguration config, ICustomAuthenticationService customAuthenticationService)
    {
        _config = config;
        _customAuthenticationService = customAuthenticationService;
    }

    [HttpPost("authenticate")]
    public ActionResult<string> Authenticate(AuthenticationRequest authenticationRequest)
    {
        string token = _customAuthenticationService.Authenticate(authenticationRequest);

        return Ok(token);
    }


}