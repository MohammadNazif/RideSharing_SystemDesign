using MediatR;
using RideSharing.Infrastructure;
using RideSharing.Api.Endpoints;
using RideSharing.Application.Drivers.Queries;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Serilog First
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

// 2️⃣ Tell ASP.NET to use Serilog
builder.Host.UseSerilog();

// 3️⃣ Add Services
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetDriverQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(DriverLocationUpdatedEventHandler).Assembly);
});

// 4️⃣ Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// 5️⃣ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 6️⃣ Build
var app = builder.Build();

// 7️⃣ Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 8️⃣ Routes
app.MapEndpointsDriver();

// 9️⃣ Run
app.Run();

// 🔟 Serilog Cleanup
Log.CloseAndFlush();
