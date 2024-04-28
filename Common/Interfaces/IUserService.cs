using Common.Models;

namespace Common.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserModel>> GetAll();
    Task<UserModel?> Get(long id);
    Task<UserModel?> Create(UserModel user);
    Task<UserModel?> Update(long id, UserModel user);
    Task<bool?> Delete(long id);
}
