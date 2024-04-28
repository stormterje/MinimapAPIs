using Common.Interfaces;
using Common.Models;

namespace Common.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string dbLock = "dbLock";
    private static Dictionary<long, UserModel> db = new Dictionary<long, UserModel>
    {
        { 1, new UserModel {
            Id = 1,
            Email = "tberg@stormgeo.com",
            FirstName = "Terje",
            LastName = "Bergesen",
            Username = "tberg"
        }},
        { 2, new UserModel {
            Id = 1,
            Email = "terje@bergesen.info",
            FirstName = "Terje",
            LastName = "Bergesen",
            Username = "terje"
        }}
    };
    public async Task<UserModel?> Create(UserModel user)
    {
        await Task.Delay(1);
        lock (dbLock)
        {
            long newId = db.Keys.Count > 0 ? db.Keys.Max() + 1 : 1;
            user.Id = newId;
            db[user.Id] = user;
        }
        return user;
    }

    public async Task<bool> Delete(long id)
    {
        await Task.Delay(1);
        if (db.ContainsKey(id))
        {
            var retval = db[id];
            db.Remove(id);
            return true;
        }
        return false;
    }

    public async Task<UserModel?> Get(long id)
    {
        await Task.Delay(1);
        if (db.ContainsKey(id))
        {
            return db[id];
        }
        return null;
    }

    public async Task<IEnumerable<UserModel>> GetAll()
    {
        await Task.Delay(1);
        return db.Values;
    }

    public async Task<UserModel?> Update(long id, UserModel user)
    {
        await Task.Delay(1);
        if (db.ContainsKey(id))
        {
            user.Id = id;
            db[id] = user;
            return user;
        }
        return null;
    }
}