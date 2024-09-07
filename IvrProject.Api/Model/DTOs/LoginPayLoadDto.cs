using System;

namespace IvrProject.Api.Model.DTOs;

public class LoginPayLoadDto
{
    public required string name { get; set; }
    public required string Password { get; set; }
}
