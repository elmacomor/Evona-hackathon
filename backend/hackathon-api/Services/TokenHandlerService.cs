using hackathon_api.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace hackathon_api.Services;
public class TokenHandlerService : ITokenHandlerService
{
    private readonly IConfiguration configuration;
    public TokenHandlerService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public async Task<string> CreateTokenAsync(LoginDTO user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]));
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
        //claims.Add(new Claim(ClaimTypes.Email, user.Email)); 

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials
            );
        return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

    }
}
