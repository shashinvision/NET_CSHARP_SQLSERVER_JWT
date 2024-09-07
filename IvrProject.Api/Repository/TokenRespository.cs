using System.Data;
using System.Data.SqlClient;
using IvrProject.Api.Model;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model.Entities;
using Dapper;


namespace IvrProject.Api.Repository;

public class TokenRespository : DbContext
{
    public TokenRespository(string connectionString) : base(connectionString)
    {
    }


    public async Task<bool> StoreRefreshToken(RefreshToken refreshToken)
    {

        Connect();
        try
        {
            string storedProcedure = "SP_TOKEN_ADD";

            // Use _connection from the father class
            var refresh_token = await _connection.QuerySingleOrDefaultAsync<RefreshToken>(
                storedProcedure,
                refreshToken,
                commandType: CommandType.StoredProcedure
            );

            if (refresh_token != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
        finally
        {
            Close();
        }

    }

    public async Task<RefreshToken> GetRefreshToken(string refreshToken)
    {

        Connect();
        try
        {
            string storedProcedure = "SP_TOKEN_GET_BY_TOKEN";

            // Use _connection from the father class
            var refresh_token = await _connection.QuerySingleOrDefaultAsync<RefreshToken>(
                storedProcedure,
                new { token = refreshToken },
                commandType: CommandType.StoredProcedure
            );

            if (refresh_token != null)
            {
                return refresh_token;
            }
            else
            {
                return null!;
            }
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return null!;
        }
        finally
        {
            Close();
        }

    }


    public async Task<RefreshToken> GetRefreshTokenByUser(int userId)
    {

        Connect();
        try
        {
            string storedProcedure = "SP_TOKEN_GET_BY_USER";

            // Use _connection from the father class
            var refresh_token = await _connection.QuerySingleOrDefaultAsync<RefreshToken>(
                storedProcedure,
                new { id_user = userId },
                commandType: CommandType.StoredProcedure
            );

            if (refresh_token != null)
            {
                return refresh_token;
            }
            else
            {
                return null!;
            }
        }

        catch (System.Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return null!;
        }
        finally
        {
            Close();
        }

    }
}
