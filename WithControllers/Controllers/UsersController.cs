namespace WithControllers.Controllers;

using Microsoft.AspNetCore.Mvc;

public class UserModel
{
    public long Id;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    public static UserModel user = new UserModel
    {
        Id = 10_000_000,
        Email = "tberg@stormgeo.com",
        Username = "tberg",
        FirstName = "Terje",
        LastName = "Bergeesen",
    };

    [HttpGet("{id}")]
    public async Task<IResult> GetUser(long id)
    {
        return Results.Ok(user);
    }
}