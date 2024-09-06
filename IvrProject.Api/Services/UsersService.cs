using System;
using SQL_SERVER_API.DTOs;
using SQL_SERVER_API.Model.Entities;
using SQL_SERVER_API.Interfaces;
using SQL_SERVER_API.Repository;
namespace SQL_SERVER_API.Services;

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
        _userRepository.Connect();

        List<UserDto> users = await _userRepository.GetUsers();

        _userRepository.Close();

        return users;
    }
    public async Task<List<UserDto>> GetById(int idUser)
    {
        _userRepository.Connect();

        List<UserDto> users = await _userRepository.GetUserById(idUser);

        _userRepository.Close();

        return users;
    }
    public async Task<List<UserDto>> GetByName(UserDto user)
    {
        _userRepository.Connect();

        List<UserDto> users = await _userRepository.GetUserByName(user);

        _userRepository.Close();

        return users;
    }

    public async Task<List<InsertedUserDto>> Add(User user)
    {
        UserDto userDto = new UserDto(){
            name = user.name,
            roleId = user.roleId
        };

        var userFound = await GetByName(userDto);

        if (userFound.Count > 0) return new List<InsertedUserDto>();

        _userRepository.Connect();

        List<InsertedUserDto> users = await _userRepository.AddUser(user);

        _userRepository.Close();

        return users;
    }

    public async Task<List<UserDto>> Update(User user)
    {
        _userRepository.Connect();

        List<UserDto> users = await _userRepository.UpdateUser(user);

        _userRepository.Close();

        return users;
    }

    public async Task<List<UserDto>> Delete(int idUser)
    {

        _userRepository.Connect();

        List<UserDto> users = await _userRepository.DeleteUser(idUser);

        _userRepository.Close(); 
        
        return users;
      
    }

}
