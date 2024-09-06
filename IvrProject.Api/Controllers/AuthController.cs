using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SQL_SERVER_API.DTOs;
using SQL_SERVER_API.Services;
using SQL_SERVER_API.Interfaces;

namespace SQL_SERVER_API.Controllers;


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
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var userJwtArray = await _authService.Login(loginDto);

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
    public async Task<IActionResult> RefreshToken([FromBody] PostRefreshTokenDto refreshTokenDto)
    {

        var refresh = refreshTokenDto;

        try
        {
            List<UserDto> userList = await _authService.VerifyAndRetrieveUserByRefreshToken(refresh.RefreshToken);


            var userDto = userList.First();

            if (userDto == null)
            {
                throw new Exception("Invalid refresh token");
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
