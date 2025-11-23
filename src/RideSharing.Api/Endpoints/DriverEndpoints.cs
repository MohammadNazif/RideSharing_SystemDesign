using System.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RideSharing.Application.Drivers.Commands.CreateDriver;
using RideSharing.Application.Drivers.Commands.UpdateLocation;
using RideSharing.Application.Drivers.Queries;
using RideSharing.Application.Drivers.Queries.GetDriverById;
using RideSharing.Domain.Common;
using RideSharing.Domain.Entities;
using RideSharing.Domain.Enums;

namespace RideSharing.Api.Endpoints
{
    public static class DriverEndpoints
    {

        public static void MapEndpointsDriver(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/drivers");


            group.MapGet("/", async ([FromServices]  IMediator mediator) =>
            {
                var result = await mediator.Send(new GetDriverQuery());
                return Results.Ok(result);
            });

            group.MapGet("/{id:guid}", async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
            {
               var drivers = await mediator.Send(new GetDriverByIdQuery(id));
                return Results.Ok(drivers);
            });

            group.MapPost("/", async (CreateDriverCommand cmd,IMediator mediator) =>
            {
                var id = await mediator.Send(cmd);
                return Results.Created($"/drivers/{id}", id);
            });

          
            group.MapPut("/{id:guid}/location", async ([FromRoute] Guid id, UpdateDriverLocationCommand cmd,IMediator mediator) =>
            {

                var driver = await mediator.Send(cmd);
                return Results.Ok(driver);
            });


            group.MapPut("/{id:guid}/Status", async ([FromRoute] Guid id, UpdateStatus cmd, IMediator mediator) =>
            {

                var driver = await mediator.Send(cmd);
                return Results.Ok(driver);
            });

        }
    }
}
public record DriverDto(string Name, string PhoneNumber);
public record DriverLocationDto(double Latitude, double Longitude);
public record DriverStatusDto(DriverStatus Status);