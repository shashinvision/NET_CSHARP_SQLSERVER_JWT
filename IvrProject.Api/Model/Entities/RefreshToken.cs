using System;

namespace IvrProject.Api.Model.DTOs;

public class RefreshToken
{
    public int id_user { get; set; }
    public string? refresh_token { get; set; }
    public DateTime expire { get; set; }
}
