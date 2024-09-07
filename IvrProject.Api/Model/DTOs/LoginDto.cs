using System;

namespace IvrProject.Api.Model.DTOs;

public class LoginDto
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }

    public int role_id { get; set; }
}
