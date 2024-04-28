namespace WithControllers.Controllers;

using Common.Interfaces;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IResult> Get()
    {
        return Results.Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetUser(long id)
    {
        var user = await _service.Get(id);
        return user != null ? Results.Ok(user) : Results.NotFound();
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] UserModel user)
    {
        var newUser = await _service.Create(user);
        return newUser != null ? Results.Ok(newUser) : Results.BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IResult> Put(long id, [FromBody] UserModel user)
    {
        var updateUser = await _service.Update(id, user);
        return updateUser != null ? Results.Ok(updateUser) : Results.NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(long id)
    {
        var toDelete = await _service.Get(id);
        if (toDelete == null)
        {
            return Results.NotFound();
        }
        await _service.Delete(id);
        return Results.Ok();
    }
}