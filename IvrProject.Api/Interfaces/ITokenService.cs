using System;
using SQL_SERVER_API.DTOs;
using SQL_SERVER_API.Model.Entities;

namespace SQL_SERVER_API.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(UserDto userDto);
    Task<string> GenerateRefreshToken(UserDto userDto);
    Task<RefreshToken> GetRefreshToken(string refreshToken);
    Task<string> verifyExpiredToken(UserDto userDto);
}
