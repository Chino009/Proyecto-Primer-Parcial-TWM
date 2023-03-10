using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories;

public class GameUserRepository: IGameUserRepository
{
    private readonly List<GameUser> _user;

    public GameUserRepository()
    {
        _user = new List<GameUser>();
    }
    public async Task<GameUser> SaveAsync(GameUser user)
    {
        user.id = _user.Count + 1;
        _user.Add(user);
        return user;
    }
    public async Task<GameUser> UpdateAsync(GameUser user)
    {
        var index = _user.FindIndex(x => x.id == user.id);

        if (index != -1)
            _user[index] = user;
        return await Task.FromResult(user);
    }
    public async Task<List<GameUser>> GetAllAsync()
    {
        return _user;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        _user.RemoveAll(x => x.id == id);
        return true;
    }
    public async Task<GameUser> GetById(int id)
    {
        var purchased = _user.FirstOrDefault(x => x.id == id);
        return await Task.FromResult(purchased);
    }
}