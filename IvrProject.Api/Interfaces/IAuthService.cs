using System;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model.Entities;
namespace IvrProject.Api.Interfaces;

public interface IAuthService
{
    Task<List<string>> Login(LoginPayLoadDto loginPayLoadDto);
    Task<User> GetUserToLogin(LoginPayLoadDto loginPayLoadDto);
    Task<UserDto> VerifyAndRetrieveUserByRefreshToken(string refreshToken);
}
