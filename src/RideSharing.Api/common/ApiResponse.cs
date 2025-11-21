namespace RideSharing.Api.Common;

public static class ApiResponse
{
    public static async Task<IResult> Execute(Func<Task<IResult>> action)
    {
        try
        {
            return await action();
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(new { success = false, message = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return Results.NotFound(new { success = false, message = ex.Message });
        }
        catch (UnauthorizedAccessException)
        {
            return Results.Unauthorized();
        }
        catch (Exception ex)
        {
            // TODO: replace with real logger
            Console.Error.WriteLine(ex);
            return Results.StatusCode(500);
        }
    }

    public static IResult Success(object? data = null, int status = 200)
    {
        return Results.Json(new { success = true, data }, statusCode: status);
    }
}
