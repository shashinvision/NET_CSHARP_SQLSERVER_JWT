using System;
using SQL_SERVER_API.DTOs;
using SQL_SERVER_API.Model.Entities;
using SQL_SERVER_API.Interfaces;
using SQL_SERVER_API.Repository;
using SQL_SERVER_API.Helpers;

namespace SQL_SERVER_API.Services;

public class AuthService : IAuthService
{

    private readonly UserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly ITokenService _tokenService;

    public AuthService(IConfiguration configuration, ITokenService tokenService)
    {
        _configuration = configuration;

        string? connectionString = _configuration.GetConnectionString("SqlConnection");

        _userRepository = new UserRepository(connectionString);
        _tokenService = tokenService;

    }

    public async Task<LoginDto> GetUserToLogin(LoginDto user)
    {
        _userRepository.Connect();

        LoginDto loginDto = await _userRepository.GetUserToLogin(user);

        _userRepository.Close();


        return loginDto;
    }

    public async Task<List<string>> Login(LoginDto loginDto)
    {

        LoginDto user = await _userRepository.GetUserToLogin(loginDto);

        if (user == null) throw new Exception("User not found");

        bool verified = EncryptString.VerifyPassword(loginDto.Password, user.Password);

        if (!verified) throw new Exception("Password incorrect");

        UserDto userDto = new UserDto
        {
            id = user.Id,
            name = user.Username,
            roleId = user.roleId
        };

        // Generate JWT token
        var token = _tokenService.GenerateJwtToken(userDto);

      
        // Generate refresh token, but only if the token is not expired
        string refresh_token = await _tokenService.verifyExpiredToken(userDto);

        if(refresh_token == "" || refresh_token == null) {

            refresh_token = await _tokenService.GenerateRefreshToken(userDto);
        }
                 

        if (refresh_token == "" || refresh_token == null)
        {
            refresh_token = "Error generating refresh token";
        }

        return new List<string> { token, refresh_token.ToString() };

    }


    public async Task<List<UserDto>> VerifyAndRetrieveUserByRefreshToken(string refreshToken)
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
        int userid = Convert.ToInt32(getRefreshToken.IdUser);
        DateTime expireDate = DateTime.Parse(getRefreshToken.Expire);
        DateTime now = DateTime.Now;

        // Validate the user ID and expiration date
        if (userid < 1 || now > expireDate)
        {
            throw new Exception("Invalid refresh token");
        }

        // Retrieve the user by ID
        return await _userRepository.GetUserById(userid);
    }


}
