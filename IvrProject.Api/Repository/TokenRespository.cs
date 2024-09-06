using System;
using System.Data;
using System.Data.SqlClient;
using SQL_SERVER_API.Model;
using SQL_SERVER_API.Model.Entities;

namespace SQL_SERVER_API.Repository;

public class TokenRespository : DbContext
{
    public TokenRespository(string connectionString) : base(connectionString)
    {
    }


        public async Task<bool> StoreRefreshToken(int userId, string refreshToken, string expire)
    {


        Connect();

        string query = "INSERT INTO token_refresh (id_user, refresh_token, expire) VALUES (@idUser, @refreshToken, @expire)";

        try
        {
            // _connection come from base (Father class)
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@idUser", userId);
            command.Parameters.AddWithValue("@refreshToken", refreshToken);
        command.Parameters.Add("@expire", SqlDbType.DateTime).Value = expire;
            await command.ExecuteNonQueryAsync();

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            return false;
            throw;
        }

        Close();

        return true;

    }

    public async Task<RefreshToken> GetRefreshToken(string refreshToken){

        RefreshToken TokenRefresh;

        Connect();

        string query = "SELECT id_user, refresh_token, expire FROM token_refresh WHERE refresh_token = @refreshToken";

        try
        {
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@refreshToken", refreshToken);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            await reader.ReadAsync();
            {
                int id_user = reader.GetInt32(0);
                string refresh_token = reader.GetString(1);
                DateTime expire = reader.GetDateTime(2);

                TokenRefresh = new RefreshToken
                {
                    IdUser = id_user,
                    Token = refresh_token,
                    Expire = expire.ToString() // Convert DateTime to string if needed
                };
            }

        }
         catch (System.Exception ex)
        {
            Console.WriteLine("Error on GetRefreshToken:" + ex.Message);
            throw;
        }

        Close();
        return TokenRefresh;
        
    }


        public async Task<RefreshToken> GetRefreshTokenByUser(int userId){

        RefreshToken TokenRefresh;

        Connect();
        
        // I just want the last one by id
        string query = "SELECT TOP 1 id_user, refresh_token, expire FROM token_refresh WHERE id_user = @userId ORDER BY id DESC";

        try
        {
            SqlCommand command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@userId", userId);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            await reader.ReadAsync();
            {
                int id_user = reader.GetInt32(0);
                string refresh_token = reader.GetString(1);
                DateTime expire = reader.GetDateTime(2);

                TokenRefresh = new RefreshToken
                {
                    IdUser = id_user,
                    Token = refresh_token,
                    Expire = expire.ToString() // Convert DateTime to string if needed
                };
            }

        }
         catch (System.Exception ex)
        {
            Console.WriteLine("Error on GetRefreshToken:" + ex.Message);
            throw;
        }

        Close();
        return TokenRefresh;
        
    }
}
