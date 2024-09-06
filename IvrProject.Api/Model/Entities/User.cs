using System;

namespace SQL_SERVER_API.Model.Entities;

public class User
{
    public int id { get; set; }
    public string? name { get; set; }
    public int roleId { get; set; }
    public string? password { get; set; }
}
