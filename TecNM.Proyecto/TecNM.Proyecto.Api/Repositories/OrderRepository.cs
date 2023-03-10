using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories;

public class OrderRepository: IOrderRepository
{
    private readonly List<Order> _order;

    public OrderRepository()
    {
        _order = new List<Order>();
    }
    public async Task<Order> SaveAsync(Order order)
    {
        order.id = _order.Count + 1;
        _order.Add(order);
        return order;
    }
    public async Task<Order> UpdateAsync(Order order)
    {
        var index = _order.FindIndex(x => x.id == order.id);
        if (index != -1)
            _order[index] = order;
        return await Task.FromResult(order);
    }
    public async Task<List<Order>> GetAllAsync()
    {
        return _order;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        _order.RemoveAll(x => x.id == id);
        return true;
    }
    public async Task<Order> GetById(int id)
    {
        var success = _order.FirstOrDefault(x => x.id == id);
        return await Task.FromResult(success);
    }
}