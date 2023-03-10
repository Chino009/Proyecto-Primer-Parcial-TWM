using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IGameUserRepository
{
    //Metodo para guardar categorias
    Task<GameUser> SaveAsync(GameUser user);
    
    //Metodo para Actualizar las categorias
    Task<GameUser> UpdateAsync(GameUser user);
    
    //Metodo para retonar una lista de categorias
    Task<List<GameUser>> GetAllAsync();
    
    //Metodo para retornar el id de las catevorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<GameUser> GetById(int id); 
}
