namespace WithMinimallAPIs.Endpoints;

using Microsoft.AspNetCore.Mvc;
using WithMinimallAPIs.Endpoints.Configuration;

public class UserModel
{
    public long Id;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

public class UserEndpoints : IEndpoints
{
    public static UserModel user = new UserModel
    {
        Id = 10_000_000,
        Email = "tberg@stormgeo.com",
        Username = "tberg",
        FirstName = "Terje",
        LastName = "Bergeesen",
    };

    public static void AddServices(IServiceCollection services)
    {
    }

    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        var userEndponts = app.MapGroup("/api/users").WithTags("Users").WithOpenApi();
        userEndponts.MapGet("/{id:long}", GetUser)
            .WithName(nameof(GetUser))
            .WithDescription("Get a specific user (by id) from the database")
            .Produces<UserModel>(200)
            .Produces(404);
    }


    private static async Task<IResult> GetUser(long id)
    {
        return Results.Ok(user);
    }
}