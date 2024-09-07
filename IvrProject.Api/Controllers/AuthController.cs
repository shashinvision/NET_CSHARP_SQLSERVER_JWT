using Microsoft.AspNetCore.Mvc;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Interfaces;

namespace IvrProject.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;

    public AuthController(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginPayLoadDto loginPayLoadDto)
    {
        try
        {
            var userJwtArray = await _authService.Login(loginPayLoadDto);

            var user_jwt = userJwtArray[0];
            var refreshToken = userJwtArray[1];

            return Ok(new { user_jwt, refreshToken });
        }
        catch (System.Exception ex)
        {

            return Unauthorized("Error: " + ex.Message);
        }

    }

    [HttpPost("refreshtoken")]
    public async Task<IActionResult> RefreshToken([FromBody] PostRefreshToken RefreshToken)
    {

        var refresh = RefreshToken;

        try
        {
            UserDto userDto = await _authService.VerifyAndRetrieveUserByRefreshToken(refresh.RefreshToken);

            if (userDto == null)
            {
                return BadRequest("Invalid refresh token");
            }

            // Generate a new JWT token
            string user_jwt = _tokenService.GenerateJwtToken(userDto);

            return Ok(new { user_jwt });
        }
        catch (System.Exception)
        {

            return BadRequest("Invalid refresh token");
        }


    }

}
