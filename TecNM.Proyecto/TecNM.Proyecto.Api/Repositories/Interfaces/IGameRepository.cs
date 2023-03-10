using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IGameRepository
{
    //Metodo para guardar categorias
    Task<Game> SaveAsync(Game game);
    
    //Metodo para Actualizar las categorias
    Task<Game> UpdateAsync(Game game);
    
    //Metodo para retonar una lista de categorias
    Task<List<Game>> GetAllAsync();
    
    //Metodo para retornar el id de las catevorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Game> GetById(int id); 
}