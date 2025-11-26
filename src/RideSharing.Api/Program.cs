using MediatR;
using RideSharing.Infrastructure;
using RideSharing.Api.Endpoints;
using RideSharing.Application.Drivers.Queries;
using MediatR.Registration;
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// register MediatR scanning Application assembly
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetDriverQuery).Assembly);
});

// register infra (DbContext, UnitOfWork, repos)
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpointsDriver(); // your endpoint mapping that uses mediator

app.Run();
