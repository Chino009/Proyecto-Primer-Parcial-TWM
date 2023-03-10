using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IOrderDetailRepository
{
    //Metodo para guardar categorias
    Task<OrderDetail> SaveAsync(OrderDetail order);
    
    //Metodo para Actualizar las categorias
    Task<OrderDetail> UpdateAsync(OrderDetail order);
    
    //Metodo para retonar una lista de categorias
    Task<List<OrderDetail>> GetAllAsync();
    
    //Metodo para retornar el id de las catevorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<OrderDetail> GetById(int id);   
}