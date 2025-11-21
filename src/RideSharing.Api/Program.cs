using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using RideSharing.Infrastructure;
using RideSharing.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container
builder.Services.AddControllers();

builder.Services.AddInfrastructure(builder.Configuration);
// ⚡ Add Swagger generation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // <-- This is required

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RideSharing API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapAuthEndpoints();


app.Run();
