using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController: Controller
{
    private readonly IOrderRepository _orderRepository;
    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<Order>>>> GetAll()
    {
        var order = await _orderRepository.GetAllAsync();
        var response = new Response<List<Order>>();
        response.Data = order;
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<Order>>> Post([FromBody] Order order)
    {
        order = await _orderRepository.SaveAsync(order);
        var response = new Response<Order>();
        response.Data = order;
        return Created($"/api/[controller]/{order.id}", response);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Order>>> GetById(int id)
    {
        var order = await _orderRepository.GetById(id);
        var response = new Response<Order>();
        response.Data = order;

        return Ok(response);
    }
    [HttpPut]
    public async Task<ActionResult<Response<Order>>> Update([FromBody] Order order)
    {
        var result = await _orderRepository.UpdateAsync(order);
        var response = new Response<Order>{Data = result};
        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _orderRepository.DeleteAsync(id);
        var response = new Response<bool>();
        return Ok(result);
    }
}