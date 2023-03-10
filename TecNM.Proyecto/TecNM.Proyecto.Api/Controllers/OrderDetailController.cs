using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController: Controller
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    public OrderDetailController(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<OrderDetail>>>> GetAll()
    {
        var order = await _orderDetailRepository.GetAllAsync();
        var response = new Response<List<OrderDetail>>();
        response.Data = order;
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<OrderDetail>>> Post([FromBody] OrderDetail order)
    {
        order = await _orderDetailRepository.SaveAsync(order);
        var response = new Response<OrderDetail>();
        response.Data = order;
        return Created($"/api/[controller]/{order.id}", response);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<OrderDetail>>> GetById(int id)
    {
        var order = await _orderDetailRepository.GetById(id);
        var response = new Response<OrderDetail>();
        response.Data = order;
        return Ok(response);
    }
    [HttpPut]
    public async Task<ActionResult<Response<OrderDetail>>> Update([FromBody] OrderDetail order)
    {
        var result = await _orderDetailRepository.UpdateAsync(order);
        var response = new Response<OrderDetail>{Data = result};
        return Ok(response);
    }
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _orderDetailRepository.DeleteAsync(id);
        var response = new Response<bool>();
        return Ok(result);
    }
}