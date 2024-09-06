using System;
using System.ComponentModel.DataAnnotations;

namespace SQL_SERVER_API.Model.Entities;

public class RefreshToken
{
    public int IdUser { get; set; }
    
    [Required]
    public string? Token { get; set; }
    public string? Expire { get; set; }
}
