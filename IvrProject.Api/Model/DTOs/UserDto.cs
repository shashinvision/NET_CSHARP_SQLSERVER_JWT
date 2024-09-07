using System;

namespace IvrProject.Api.Model.DTOs;

public class UserDto
{
    public int id { get; set; }
    public string? name { get; set; }
    public int role_id { get; set; }
    public string? role_name { get; set; }

    public int? status { get; set; }
}
