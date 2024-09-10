using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model.Entities;
using IvrProject.Api.Services;
using IvrProject.Api.Interfaces;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.



builder.Services.AddScoped<ICommService<UserAddDto, UserDto, InsertedUserDto>, UsersService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();


var jwtSection = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSection.GetValue<string>("Issuer"),
            ValidAudience = jwtSection.GetValue<string>("Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection.GetValue<string>("Secret"))),
            RoleClaimType = ClaimTypes.Role

        };
    });

builder.Services.AddCors(options =>
    {
        options.AddPolicy("PermitirApiRequest", builder =>
        {
            builder.WithOrigins("*")  // Only allow specific origin
                  .AllowAnyHeader()  // Allow any header, like Authorization
                  .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");  // Allow necessary HTTP methods
        });
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("PermitirApiRequest");

app.UseHttpsRedirection();

app.UseAuthentication(); // to use JWT 
app.UseAuthorization();

app.MapControllers();

app.Run();
