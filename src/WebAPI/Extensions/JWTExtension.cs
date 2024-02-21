using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Extensions;

public static class JWTExtension
{
    public static void AddJWT(this IServiceCollection services, IConfiguration configuration)
    {
        const string tokenOptionsConfigurationSection = "TokenOptions";
        var tokenOptions =
            configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
            ?? throw new InvalidOperationException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration.");

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });
    }
}
