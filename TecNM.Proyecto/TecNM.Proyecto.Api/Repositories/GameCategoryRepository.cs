using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories;

public class GameCategoryRepository: IGameCategoryRepository
{
    private readonly List<GameCategory> _categories;

    public GameCategoryRepository()
    {
        _categories = new List<GameCategory>();
    }
    public async Task<GameCategory> SaveAsync(GameCategory category)
    {
        category.id = _categories.Count + 1;
        _categories.Add(category);

        return category;
    }
    public async Task<GameCategory> UpdateAsync(GameCategory category)
    {
        var index = _categories.FindIndex(x => x.id == category.id);
        if (index != -1)
            _categories[index] = category;
        return await Task.FromResult(category);
    }

    public async Task<List<GameCategory>> GetAllAsync()
    {
        return _categories;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        _categories.RemoveAll(x => x.id == id);
        return true;
    }
    public async Task<GameCategory> GetById(int id)
    {
        var category = _categories.FirstOrDefault(x => x.id == id);
        return await Task.FromResult(category);
    }
}