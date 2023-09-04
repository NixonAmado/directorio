using Microsoft.EntityFrameworkCore;
using Persistencia;
using API.Controllers;
using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Persistencia.Data;

using System.Reflection;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//*****************
builder.Services.ConfigureCors();
builder.Services.AddAplicationServices();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly())
builder.Services.ConfigureRateLimiting();
//*****************

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//*****************
builder.Services.AddDbContext<directorioContext>(optionsBuilder =>
{
    string ? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});

//*****************

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy"); //- le decimos que use el cors "CorsPolicy"
app.UseAuthorization();
app.MapControllers();
app.Run();