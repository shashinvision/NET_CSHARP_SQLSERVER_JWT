using System;

namespace SQL_SERVER_API.DTOs;

public class UserDto
{
    public int id { get; set; }
    public string? name { get; set; }
    public int roleId { get; set; }
}
