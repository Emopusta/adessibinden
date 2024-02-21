using WebAPI.Utils;

namespace WebAPI.Extensions;

public static class CorsConfigurationExtension
{
    public static void AddCorsConfiguration(this IApplicationBuilder app, IConfiguration configuration)
    {
        const string webApiConfigurationSection = "WebAPIConfiguration";
        var webApiConfiguration =
            configuration.GetSection(webApiConfigurationSection).Get<WebApiConfiguration>()
            ?? throw new InvalidOperationException($"\"{webApiConfigurationSection}\" section cannot found in configuration.");
        app.UseCors(opt => opt.WithOrigins(webApiConfiguration.AllowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
    }
}
