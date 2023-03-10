using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories;

public class GameRepository: IGameRepository
{
    private readonly List<Game> _game;

    public GameRepository()
    {
        _game = new List<Game>();
    }
    public async Task<Game> SaveAsync(Game game)
    {
        game.id = _game.Count + 1;
        _game.Add(game);
        return game;
    }
    public async Task<Game> UpdateAsync(Game game)
    {
        var index = _game.FindIndex(x => x.id == game.id);
        if (index != -1)
            _game[index] = game;
        return await Task.FromResult(game);
    }
    public async Task<List<Game>> GetAllAsync()
    {
        return _game;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        _game.RemoveAll(x => x.id == id);
        return true;
    }
    public async Task<Game> GetById(int id)
    {
        var product = _game.FirstOrDefault(x => x.id == id);

        return await Task.FromResult(product);
    }
}