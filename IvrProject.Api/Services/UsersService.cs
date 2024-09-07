using System;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model.Entities;
using IvrProject.Api.Interfaces;
using IvrProject.Api.Repository;
namespace IvrProject.Api.Services;

public class UsersService : ICommService<UserAddDto, UserDto, InsertedUserDto>
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
    public async Task<UserDto> GetByName(string userName)
    {
        UserDto users = await _userRepository.GetUserByName(userName);

        return users;
    }

    public async Task<InsertedUserDto> Add(UserAddDto userAddDto)
    {
        UserDto userDto = new UserDto()
        {
            name = userAddDto.name,
            role_id = userAddDto.role_id
        };

        var userFound = await GetByName(userDto.name);

        if (userFound != null) return null!;

        InsertedUserDto userAdd = await _userRepository.AddUser(userAddDto);

        return userAdd;
    }

    public async Task<UserDto> Update(UserAddDto userAddDto)
    {
        UserDto userDto = await _userRepository.UpdateUser(userAddDto);

        return userDto;
    }

    public async Task<UserDto> Delete(int idUser)
    {

        UserDto userDto = await _userRepository.DeleteUser(idUser);

        return userDto;

    }

}
