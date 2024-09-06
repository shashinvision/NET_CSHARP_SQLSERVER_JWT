using System.Data.SqlClient;
using SQL_SERVER_API.DTOs;
using SQL_SERVER_API.Model;
using SQL_SERVER_API.Model.Entities;
using SQL_SERVER_API.Helpers;
using System.Data;

namespace SQL_SERVER_API.Repository;

public class UserRepository : DbContext
{

    public UserRepository(string connectionString) : base(connectionString)
    {
    }


    public async Task<List<UserDto>> GetUsers()
    {

        Connect();

        List<UserDto> users = new List<UserDto>();
        string query = "SELECT id, name, role_id FROM users order by id asc";

        try
        {
            // _connection come from base (Father class)
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {

                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int roleId = reader.GetInt32(2);

                users.Add(new UserDto(){
                    id = id,
                    name = name,
                    roleId = roleId
                });
            }

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            throw;
        }

        Close();
        return users;

    }
    public async Task<List<UserDto>> GetUserById(int idUser)
    {

        Connect();

        List<UserDto> users = new List<UserDto>();
        string query = "SELECT id, name, role_id FROM users WHERE id = @id";

        try
        {
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", idUser);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {

                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int roleId = reader.GetInt32(2);

                users.Add(new UserDto(){
                    id = id,
                    name = name,
                    roleId = roleId
                });
            }

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            throw;
        }

        Close();
        return users;

    }
    public async Task<List<UserDto>> GetUserByName(UserDto user)
    {

        Connect();

        List<UserDto> users = new List<UserDto>();
        string query = "SELECT id, name, role_id FROM users WHERE lower(name) = @name";

        try
        {
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", user.name?.ToLower());
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {

                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int roleId = reader.GetInt32(2);

                users.Add(new UserDto(){
                    id = id,
                    name = name,
                    roleId = roleId
                });
            }

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            throw;
        }

        Close();
        return users;

    }
    public async Task<List<InsertedUserDto>> AddUser(User user)
    {

        string encryptedPassword = EncryptString.EncryptPassword(user.password);

        Connect();

        List<InsertedUserDto> users = new List<InsertedUserDto>();
        string query = "INSERT INTO users (name, role_id, password) VALUES (@name, @role_id, @password)";

        try
        {
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", user.name);
            command.Parameters.AddWithValue("@role_id", user.roleId);
            command.Parameters.AddWithValue("@password", encryptedPassword);
            await command.ExecuteNonQueryAsync();

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            throw;
        }

        Close();

        users.Add(new InsertedUserDto(){
            name = user.name,
            roleId = user.roleId
        });
        return users;

    }
    public async Task<List<UserDto>> UpdateUser(User user)
    {

        List<UserDto> users = await GetUserById(user.id);
        if (users.Count == 0) return new List<UserDto>();

        Connect();

        try
        {
            string query = "UPDATE users SET role_id = @role_id WHERE id = @id";
            
            if (user.password != null)
            {
                query = "UPDATE users SET role_id = @role_id, password = @password WHERE id = @id";
            } 

            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", user.id);
            command.Parameters.AddWithValue("@role_id", user.roleId);
            if (user.password != null) {
                string encryptedPassword = EncryptString.EncryptPassword(user.password);
                command.Parameters.AddWithValue("@password", encryptedPassword);
            }
            await command.ExecuteNonQueryAsync();

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            throw;
        }

        Close();

        var userDto = new UserDto(){
            id = user.id,
            name = users.First().name,
            roleId = user.roleId
        };
        users.Clear();
        users.Add(userDto);
        return users;


    }
    public async Task<List<UserDto>> DeleteUser(int idUser)
    {
        List<UserDto> users = await GetUserById(idUser);
        if (users.Count == 0) return new List<UserDto>();

        Connect();

        string query = "DELETE FROM users WHERE id = @id";

        try
        {
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@id", idUser);
            await command.ExecuteNonQueryAsync();

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            throw;
        }

        Close();

        return users;

    }

    public async Task<LoginDto> GetUserToLogin(LoginDto user){

        LoginDto loginDto;

        Connect();

        string query = "SELECT id, name, password, role_id FROM users WHERE lower(name) = @name";

        try
        {
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@name", user.Username?.ToLower());
            SqlDataReader reader = await command.ExecuteReaderAsync();

            await reader.ReadAsync();
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string password = reader.GetString(2);
                int roleId = reader.GetInt32(3);


                loginDto = new LoginDto(){
                    Id = id,
                    Username = name,
                    Password = password,
                    roleId = roleId
                };
            }

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            throw;
        }

        Close();
        return loginDto;
    }

}
