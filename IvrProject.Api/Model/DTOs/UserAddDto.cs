using System;

namespace IvrProject.Api.Model.DTOs;

public class UserAddDto
{
    public int id { get; set; }
    public string? name { get; set; }
    public int role_id { get; set; }
    public string? password { get; set; }
}
