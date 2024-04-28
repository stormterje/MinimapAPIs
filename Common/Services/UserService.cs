using Common.Interfaces;
using Common.Models;

namespace Common.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }
    public async Task<UserModel?> Create(UserModel user)
    {
        return await _repo.Create(user);
    }

    public async Task<bool?> Delete(long id)
    {
        return await _repo.Delete(id);
    }

    public async Task<UserModel?> Get(long id)
    {
        return await _repo.Get(id);
    }

    public async Task<IEnumerable<UserModel>> GetAll()
    {
        return await _repo.GetAll();
    }

    public async Task<UserModel?> Update(long id, UserModel user)
    {
        return await _repo.Update(id, user);
    }
}