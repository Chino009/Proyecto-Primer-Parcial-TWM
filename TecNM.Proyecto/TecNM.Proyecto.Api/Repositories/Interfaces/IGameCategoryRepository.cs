using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IGameCategoryRepository
{
    //Metodo para guardar categorias
    Task<GameCategory> SaveAsync(GameCategory category);
    
    //Metodo para Actualizar las categorias
    Task<GameCategory> UpdateAsync(GameCategory category);
    
    //Metodo para retonar una lista de categorias
    Task<List<GameCategory>> GetAllAsync();
    
    //Metodo para retornar el id de las catevorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<GameCategory> GetById(int id); 
}