namespace IvrProject.Api.Model.Entities;

public class User
{
    public int id { get; set; }
    public string? name { get; set; }
    public int role_id { get; set; }
    public string? password { get; set; }
    public int status { get; set; }
}
