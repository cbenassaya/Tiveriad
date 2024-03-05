using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace ReferenceData.Integration.Apis.Middlewares;

public class ParseTokenMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        string authorization = context.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authorization) || !authorization.StartsWith("Bearer "))
        {

            await next.Invoke(context);
        }
        var token = authorization.Substring("Bearer ".Length).Trim();
        if (!string.IsNullOrEmpty(token))
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var claimsIdentity = new ClaimsIdentity(jwtToken.Claims, @"local");
            context.User = new ClaimsPrincipal(claimsIdentity);
        }
        await next.Invoke(context);
    }
}

public class MokTokenMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim("username", "johndoe"),
            new Claim("id", "123456"),
            new Claim("given_name", "John Doe"),
            new Claim("family_name", "Doe"),
            new Claim("email", "johndoe@natan.fr"),
            };
        var token = new JwtSecurityToken(context.Request.Host.Host,
            context.Request.Host.Host,
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        var tokenValue =  new JwtSecurityTokenHandler().WriteToken(token);
        context.Request.Headers["Authorization"] = "Bearer " + tokenValue;
        await next.Invoke(context);
    }
}