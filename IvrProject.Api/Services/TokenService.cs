using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using IvrProject.Api.Model.DTOs;
using IvrProject.Api.Model.Entities;
using IvrProject.Api.Interfaces;
using IvrProject.Api.Repository;


namespace IvrProject.Api.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly TokenRespository _tokenRepository;



    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;

        string? connectionString = _configuration.GetConnectionString("SqlConnection");

        _tokenRepository = new TokenRespository(connectionString);

    }

    public string GenerateJwtToken(UserDto userDto)
    {
        try
        {
            string secretKey = _configuration["Jwt:Secret"] ?? throw new InvalidOperationException("Jwt:Secret configuration is missing");
            string issuer = _configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer configuration is missing");
            string audience = _configuration["Jwt:Audience"] ?? throw new InvalidOperationException("Jwt:Audience configuration is missing");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userDto.id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                
                // Add more claims if necessary, e.g. roles or email
                new Claim(JwtRegisteredClaimNames.UniqueName, userDto.name),  // "name" claim
                // new Claim("role_id", loginDto.role_id.ToString()),  
                new Claim(ClaimTypes.Role, string.Join(",", userDto.role_name))

            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30), // Use UtcNow for consistency in distributed systems
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch (System.Exception ex)
        {
            // Log or handle the exception as necessary
            throw new InvalidOperationException("Failed to generate JWT token: " + ex.Message);
        }
    }

    public async Task<string> GenerateRefreshToken(UserDto userDto)
    {
        // Generate a random refresh token
        string refreshToken = Guid.NewGuid().ToString();

        // Calculate the expiration time
        DateTime expire = DateTime.UtcNow.AddDays(7);

        var token = new RefreshToken
        {
            id_user = userDto.id,
            refresh_token = refreshToken,
            expire = expire
        };


        // Store the refresh token in the database
        try
        {
            var result = await _tokenRepository.StoreRefreshToken(token);

            if (result) return refreshToken;
        }
        catch (System.Exception ex)
        {

            Console.WriteLine("Error:" + ex.Message);
        }

        return "";
    }

    public async Task<string> verifyExpiredToken(UserDto userDto)
    {

        try
        {
            RefreshToken result = await _tokenRepository.GetRefreshTokenByUser(userDto.id);

            if (result == null || result.refresh_token == null) return "";

            DateTime now = DateTime.Now;
            DateTime expireDate = result.expire;

            if (now < expireDate) return result.refresh_token;

        }
        catch (System.Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
            throw;
        }

        return "";

    }

    public async Task<RefreshToken> GetRefreshToken(string refreshToken)
    {
        try
        {
            RefreshToken result = await _tokenRepository.GetRefreshToken(refreshToken);

            return result;

        }
        catch (System.Exception ex)
        {

            Console.WriteLine("Error:" + ex.Message);
        }

        return null!;

    }

}
