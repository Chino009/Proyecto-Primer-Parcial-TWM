using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IOrderRepository
{
    //Metodo para guardar categorias
    Task<Order> SaveAsync(Order order);
    
    //Metodo para Actualizar las categorias
    Task<Order> UpdateAsync(Order order);
    
    //Metodo para retonar una lista de categorias
    Task<List<Order>> GetAllAsync();
    
    //Metodo para retornar el id de las catevorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<Order> GetById(int id); 
}