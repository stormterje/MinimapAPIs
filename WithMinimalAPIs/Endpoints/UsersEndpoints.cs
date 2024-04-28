namespace WithMinimallAPIs.Endpoints;

using Common.Interfaces;
using Common.Models;
using Common.Repositories;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using WithMinimallAPIs.Endpoints.Configuration;

public class UserEndpoints : IEndpoints
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
    }

    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        var userEndponts = app.MapGroup("/api/users").WithTags("Users").WithOpenApi();
        userEndponts.MapGet("/", GetAllUsers)
            .WithName(nameof(GetAllUsers))
            .WithDescription("Get all the users from the database")
            .Produces<IEnumerable<UserModel>>(200);

        userEndponts.MapGet("/{id:long}", GetUser)
            .WithName(nameof(GetUser))
            .WithDescription("Get a specific user (by id) from the database")
            .Produces<UserModel>(200)
            .Produces(404);

        userEndponts.MapPost("/", CreateUser)
            .WithName(nameof(CreateUser))
            .WithDescription("Create a new user")
            .Produces<UserModel>(200)
            .Produces(404);

        userEndponts.MapPut("/{id:long}", UpdateUser)
            .WithName(nameof(UpdateUser))
            .WithDescription("Update a user with a specified id, all values will be updated according to the body content")
            .Produces<UserModel>(200)
            .Produces(404);

        userEndponts.MapDelete("/{id:long}", DeleteUser)
            .WithName(nameof(DeleteUser))
            .WithDescription("Delete a user with a specified id")
            .Produces<UserModel>(200)
            .Produces(404);
    }


    private static async Task<IResult> GetAllUsers([FromServices] IUserService service)
    {
        return Results.Ok(await service.GetAll());
    }

    private static async Task<IResult> GetUser([FromServices] IUserService service,
                                                long id)
    {
        var user = await service.Get(id);
        return user != null ? Results.Ok(user) : Results.NotFound();
    }

    private static async Task<IResult> CreateUser([FromServices] IUserService service, [FromBody] UserModel user)
    {
        var createdUser = await service.Create(user);
        return createdUser != null ? Results.Ok(user) : Results.BadRequest();
    }

    private static async Task<IResult> UpdateUser([FromServices] IUserService service, long id, [FromBody] UserModel user)
    {
        var updateUser = await service.Update(id, user);
        return updateUser != null ? Results.Ok(user) : Results.BadRequest();
    }

    private static async Task<IResult> DeleteUser([FromServices] IUserService service, long id)
    {
        var toDelete = await service.Get(id);
        if (toDelete == null)
        {
            return Results.NotFound();
        }
        await service.Delete(id);
        return Results.Ok();
    }

}