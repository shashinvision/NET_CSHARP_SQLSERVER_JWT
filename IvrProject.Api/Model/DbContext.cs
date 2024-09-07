using System.Data.SqlClient;

namespace IvrProject.Api.Model;

public abstract class DbContext
{
    private readonly string _connectionString;
    protected SqlConnection _connection;

    protected DbContext(string connectionString)
    {

        _connectionString = connectionString;
    }

    public void Connect()
    {
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

    public void Close()
    {
        if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
    }

}
