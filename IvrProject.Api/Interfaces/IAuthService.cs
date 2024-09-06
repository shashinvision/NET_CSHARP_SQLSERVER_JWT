using System;
using SQL_SERVER_API.DTOs;
namespace SQL_SERVER_API.Interfaces;

public interface IAuthService
{
    Task<List<string>> Login(LoginDto loginDto);
    Task<LoginDto> GetUserToLogin(LoginDto user);
     Task<List<UserDto>> VerifyAndRetrieveUserByRefreshToken(string refreshToken);
}
