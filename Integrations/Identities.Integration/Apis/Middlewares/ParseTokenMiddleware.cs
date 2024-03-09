using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identities.Integration.Apis.Middlewares;

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