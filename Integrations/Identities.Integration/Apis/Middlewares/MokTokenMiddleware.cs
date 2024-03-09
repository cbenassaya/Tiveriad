using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Identities.Integration.Apis.Middlewares;


public static class TokenBuilder
{
    private static string _issuer  = Guid.NewGuid().ToString();
    private static SymmetricSecurityKey _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
    private static SigningCredentials _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
    private static string _audiance = "https://localhost";

    public static JwtSecurityToken Build(Claim[] claims)
    {
        return new JwtSecurityToken(
            _issuer,
            _audiance,
            claims,
            expires: DateTime.Now.AddDays(120),
            signingCredentials: _credentials);
    }
}

public class MokTokenMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        
        if (!string.IsNullOrEmpty(context.Request.Headers["Authorization"]))
        {
            await   next.Invoke(context);
            return;
        }
        
        var claims = new[]
        {
            new Claim("username", "johndoe"),
            new Claim("id", "65e9c3eb6d4912fa0876fe5a"),
            new Claim("given_name", "John Doe"),
            new Claim("family_name", "Doe"),
            new Claim("email", "johndoe@natan.fr"),
            new Claim("language", "en"),
            new Claim("organizationId", "65e9c859d6389f07e1893b2f"),
        };
        var tokenValue =  new JwtSecurityTokenHandler().WriteToken(TokenBuilder.Build(claims));
        context.Request.Headers["Authorization"] = "Bearer " + tokenValue;
        await next.Invoke(context);
    }
}