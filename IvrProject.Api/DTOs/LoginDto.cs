using System;

namespace SQL_SERVER_API.DTOs;

public class LoginDto
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }

    public int roleId { get; set; }
}
