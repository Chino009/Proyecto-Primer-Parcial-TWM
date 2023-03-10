using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories;

public class OrderDetailRepository: IOrderDetailRepository
{
    private readonly List<OrderDetail> _orderDetails;

    public OrderDetailRepository()
    {
        _orderDetails = new List<OrderDetail>();
    }
    public async Task<OrderDetail> SaveAsync(OrderDetail order)
    {
        order.id = _orderDetails.Count + 1;
        _orderDetails.Add(order);
        return order;
    }
    public async Task<OrderDetail> UpdateAsync(OrderDetail order)
    {
        var index = _orderDetails.FindIndex(x => x.id == order.id);
        if (index != -1)
            _orderDetails[index] = order;
        return await Task.FromResult(order);
    }
    public async Task<List<OrderDetail>> GetAllAsync()
    {
        return _orderDetails;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        _orderDetails.RemoveAll(x => x.id == id);
        return true;
    }
    public async Task<OrderDetail> GetById(int id)
    {
        var success = _orderDetails.FirstOrDefault(x => x.id == id);
        return await Task.FromResult(success);
    }
}