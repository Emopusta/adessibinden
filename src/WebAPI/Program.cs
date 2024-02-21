using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Security;
using DataAccess;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices();
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