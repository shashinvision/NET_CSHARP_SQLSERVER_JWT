using System;
using System.Data.SqlClient;

namespace SQL_SERVER_API.Model;

public abstract class DbContext
{
    private string _connectionString;
    protected SqlConnection _connection;
 
    public DbContext(string connectionString){

        _connectionString = connectionString;

        // _connectionString = $"Data Source={server};Initial Catalog={db};User ID={user};Password={password}";
    }

    public void Connect(){
        try
        {
            _connection = new SqlConnection(_connectionString);
        _connection.Open();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            throw;
        }
    }

    public void Close(){
        if(_connection != null && _connection.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
    }

}
