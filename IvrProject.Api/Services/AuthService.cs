using System;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model.Entities;
using IvrProject.Api.Interfaces;
using IvrProject.Api.Repository;
using IvrProject.Api.Helpers;

namespace IvrProject.Api.Services;

public class AuthService : IAuthService
{

    private readonly UserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IConfiguration configuration, ITokenService tokenService)
    {
        IConfiguration _configuration = configuration;

        string? connectionString = _configuration.GetConnectionString("SqlConnection");

        _userRepository = new UserRepository(connectionString);
        _tokenService = tokenService;

    }

    public async Task<User> GetUserToLogin(LoginPayLoadDto loginPayLoadDto)
    {

        var loginDto = await _userRepository.GetUserToLogin(loginPayLoadDto);

        return loginDto;
    }

    public async Task<List<string>> Login(LoginPayLoadDto loginPayLoadDto)
    {

        User user = await _userRepository.GetUserToLogin(loginPayLoadDto);

        if (user == null) return null!;

        bool verified = EncryptString.VerifyPassword(loginPayLoadDto.Password, user.password);

        if (!verified) return null!;

        UserDto userDto = new UserDto
        {
            id = user.id,
            name = user.name,
            role_id = user.role_id,
            role_name = user.role_name
        };

        // Generate JWT token
        var token = _tokenService.GenerateJwtToken(userDto);


        // Generate refresh token, but only if the token is not expired
        string refresh_token = await _tokenService.verifyExpiredToken(userDto);

        if (refresh_token == "" || refresh_token == null)
        {

            refresh_token = await _tokenService.GenerateRefreshToken(userDto);
        }


        if (refresh_token == "" || refresh_token == null)
        {
            refresh_token = "Error generating refresh token";
        }

        return new List<string> { token, refresh_token.ToString() };

    }


    public async Task<UserDto> VerifyAndRetrieveUserByRefreshToken(string refreshToken)
    {

        // Fetch the refresh token
        RefreshToken getRefreshToken = await _tokenService.GetRefreshToken(refreshToken);

        // Check if the token is null
        if (getRefreshToken == null)
        {
            // Return null immediately or handle the error appropriately
            return null!;
        }

        // Parse the user ID and expiration date
        int userid = Convert.ToInt32(getRefreshToken.id_user);
        DateTime expireDate = getRefreshToken.expire;
        DateTime now = DateTime.Now;

        // Validate the user ID and expiration date
        if (userid < 1 || now > expireDate)
        {
            return null!;
        }

        // Retrieve the user by ID
        return await _userRepository.GetUserById(userid);
    }


}
