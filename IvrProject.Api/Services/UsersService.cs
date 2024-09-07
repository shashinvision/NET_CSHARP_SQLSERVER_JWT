using System;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model.Entities;
using IvrProject.Api.Interfaces;
using IvrProject.Api.Repository;
namespace IvrProject.Api.Services;

public class UsersService : ICommService<User, UserDto, InsertedUserDto>
{
    private readonly UserRepository _userRepository;
    private readonly IConfiguration _configuration;


    public UsersService(IConfiguration configuration)
    {
        _configuration = configuration;

        string? connectionString = _configuration.GetConnectionString("SqlConnection");

        _userRepository = new UserRepository(connectionString);
    }

    public async Task<List<UserDto>> Get()
    {

        List<UserDto> users = await _userRepository.GetUsers();

        return users;
    }
    public async Task<UserDto> GetById(int idUser)
    {

        UserDto users = await _userRepository.GetUserById(idUser);

        return users;
    }
    public async Task<UserDto> GetByName(UserDto user)
    {
        UserDto users = await _userRepository.GetUserByName(user);

        return users;
    }

    public async Task<InsertedUserDto> Add(User user)
    {
        UserDto userDto = new UserDto()
        {
            name = user.name,
            role_id = user.role_id
        };

        var userFound = await GetByName(userDto);

        if (userFound != null) return null!;

        InsertedUserDto userAdd = await _userRepository.AddUser(user);

        return userAdd;
    }

    public async Task<UserDto> Update(User user)
    {
        UserDto userDto = await _userRepository.UpdateUser(user);

        return userDto;
    }

    public async Task<UserDto> Delete(int idUser)
    {

        UserDto userDto = await _userRepository.DeleteUser(idUser);

        return userDto;

    }

}
