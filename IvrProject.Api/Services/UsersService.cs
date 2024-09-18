using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Interfaces;
using IvrProject.Api.Repository;
namespace IvrProject.Api.Services;

public class UsersService : ICommService<UserAddDto, UserDto, InsertedUserDto>, IRolesService, IStatusService<UserDto>
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

        var userFound = await GetByName(userAddDto.name);

        if (userFound != null) return null!;

        InsertedUserDto userAdd = await _userRepository.AddUser(userAddDto);

        return userAdd;
    }

    public async Task<UserDto> Update(UserAddDto userAddDto)
    {
        UserDto userDto = await _userRepository.UpdateUser(userAddDto);

        return userDto;
    }

    public async Task<UserDto> Deactivate(int idUser)
    {

        UserDto userDto = await _userRepository.DeactivateUser(idUser);

        return userDto;

    }
    public async Task<UserDto> Activate(int idUser)
    {

        UserDto userDto = await _userRepository.ActivateUser(idUser);

        return userDto;

    }

    public async Task<List<RolesDto>> GetRoles()
    {
        List<RolesDto> roles = await _userRepository.GetRoles();
        return roles;
    }

}
