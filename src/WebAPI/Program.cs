using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Security;
using Core.EventBus;
using DataAccess;
using WebAPI.Extensions;
using Core.Logging.Serilog;
using Core.Cache.ServiceRegistration;
using Core.Host;

var builder = WebApplication.CreateBuilder(args);

builder.Host.SetEmopConfiguration(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices();

builder.Services.AddEmopLogger(builder.Host);
builder.Services.RegisterEventBusServices();

builder.Services.AddEmopCache();

builder.Services.AddHttpContextAccessor();

builder.Services.AddJWT(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.AddCorsConfiguration(app.Configuration);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();