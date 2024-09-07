using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model;
using IvrProject.Api.Model.Entities;
using IvrProject.Api.Helpers;
using Dapper;
using System.Data;

namespace IvrProject.Api.Repository;

public class UserRepository : DbContext
{

    public UserRepository(string connectionString) : base(connectionString)
    {
    }


    public async Task<List<UserDto>> GetUsers()
    {

        Connect();

        try
        {
            string storedProcedure = "SP_USERS_GET";

            // Use _connection from the father class
            var users = await _connection.QueryAsync<UserDto>(
                storedProcedure,
                // new { RUT = int.Parse(rutWithoutLastDigit) },
                commandType: CommandType.StoredProcedure
            );

            return users.ToList();
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            throw;
        }
        finally
        {
            Close();
        }


    }
    public async Task<UserDto> GetUserById(int idUser)
    {
        Connect();

        try
        {
            string storedProcedure = "SP_USER_GET_BY_ID";

            // Use _connection from the father class
            var user = await _connection.QuerySingleOrDefaultAsync<UserDto>(
                storedProcedure,
                new { id = idUser },
                commandType: CommandType.StoredProcedure
            );

            if (user != null && user.id > 0)
            {
                return user;
            }
            else
            {
                return null!;
            }
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            throw;
        }
        finally
        {
            Close();
        }

    }
    public async Task<UserDto> GetUserByName(string userName)
    {

        Connect();

        try
        {
            string storedProcedure = "SP_USER_GET_BY_NAME";

            // Use _connection from the father class
            var user = await _connection.QuerySingleOrDefaultAsync<UserDto>(
                storedProcedure,
                new { name = userName },
                commandType: CommandType.StoredProcedure
            );

            if (user != null && user.id > 0)
            {
                return user;
            }
            else
            {
                return null!;
            }
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            throw;
        }
        finally
        {
            Close();
        }

    }
    public async Task<InsertedUserDto> AddUser(UserAddDto userAddDto)
    {

        string encryptedPassword = EncryptString.EncryptPassword(userAddDto.password);

        Connect();

        try
        {
            string storedProcedure = "SP_USER_ADD";

            // Use _connection from the father class
            var userDto = await _connection.QuerySingleOrDefaultAsync<InsertedUserDto>(
                storedProcedure,
                new
                {
                    name = userAddDto.name,
                    role_id = userAddDto.role_id,
                    password = encryptedPassword
                },
                commandType: CommandType.StoredProcedure
            );

            if (userDto != null && userDto.name != null)
            {
                return userDto;
            }
            else
            {
                return null!;
            }
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            throw;
        }
        finally
        {
            Close();
        }

    }
    public async Task<UserDto> UpdateUser(UserAddDto userAddDto)
    {

        UserDto userByID = await GetUserById(userAddDto.id);
        if (userByID == null || userByID.id == 0) return null!;

        string encryptedPassword = EncryptString.EncryptPassword(userAddDto.password);

        Connect();

        try
        {
            if (userAddDto.password == null || userAddDto.password == "")
            {

                string storedProcedure = "SP_USER_UPDATE_ROL";
                var userDto = await _connection.QuerySingleOrDefaultAsync<UserDto>(
                    storedProcedure,
                    new
                    {
                        id = userByID.id,
                        role_id = userAddDto.role_id
                    },
                    commandType: CommandType.StoredProcedure
                );

                if (userDto != null && userDto.name != null)
                {
                    return userDto;
                }
                else
                {
                    return null!;
                }
            }
            else
            {
                string storedProcedure = "SP_USER_UPDATE_ROL_PASSWORD";

                // Use _connection from the father class
                var userDto = await _connection.QuerySingleOrDefaultAsync<UserDto>(
                    storedProcedure,
                    new
                    {
                        id = userByID.id,
                        role_id = userAddDto.role_id,
                        password = encryptedPassword
                    },
                    commandType: CommandType.StoredProcedure
                );
                if (userDto != null && userDto.name != null)
                {
                    return userDto;
                }
                else
                {
                    return null!;
                }
            }

        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            throw;
        }
        finally
        {
            Close();
        }


    }
    public async Task<UserDto> DeleteUser(int idUser)
    {

        UserDto userByID = await GetUserById(idUser);

        if (userByID == null || userByID.id == 0) return null!;

        Connect();

        try
        {
            string storedProcedure = "SP_USER_DELETE";

            // Use _connection from the father class
            var userDto = await _connection.QuerySingleOrDefaultAsync<UserDto>(
                storedProcedure,
                new { id = idUser },
                commandType: CommandType.StoredProcedure
            );

            if (userDto != null && userDto.name != null)
            {
                return userDto;
            }
            else
            {
                return null!;
            }
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            throw;
        }
        finally
        {
            Close();
        }


    }

    public async Task<User> GetUserToLogin(LoginPayLoadDto loginPayLoadDto)
    {
        Connect();

        try
        {
            string storedProcedure = "SP_USER_GET_BY_NAME";

            // Use _connection from the father class
            var user = await _connection.QuerySingleOrDefaultAsync<User>(
                storedProcedure,
                new { name = loginPayLoadDto.name },
                commandType: CommandType.StoredProcedure
            );

            if (user != null && user.id > 0)
            {
                return user;
            }
            else
            {
                return null!;
            }
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error repository: " + ex.Message);
            throw;
        }
        finally
        {
            Close();
        }
    }

}
