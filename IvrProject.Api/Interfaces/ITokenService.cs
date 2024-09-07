using System;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model.Entities;

namespace IvrProject.Api.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(UserDto userDto);
    Task<string> GenerateRefreshToken(UserDto userDto);
    Task<RefreshToken> GetRefreshToken(string refreshToken);
    Task<string> verifyExpiredToken(UserDto userDto);
}
