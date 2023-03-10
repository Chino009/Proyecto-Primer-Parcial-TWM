using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class GameUserController: Controller
{
    private readonly IGameUserRepository _gameUserRepository;
    
    public GameUserController(IGameUserRepository gameUserRepository)
    {
        _gameUserRepository = gameUserRepository;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<GameUser>>>> GetAll()
    {
        var user = await _gameUserRepository.GetAllAsync();
        var response = new Response<List<GameUser>>();
        response.Data = user;
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<GameUser>>> Post([FromBody] GameUser user)
    {
        user = await _gameUserRepository.SaveAsync(user);
        var response = new Response<GameUser>();
        response.Data = user;
        return Created($"/api/[controller]/{user.id}", response);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<GameUser>>> GetById(int id)
    {
        var purchased = await _gameUserRepository.GetById(id);
        var response = new Response<GameUser>();
        response.Data = purchased;
        return Ok(response);
    }
    [HttpPut]
    public async Task<ActionResult<Response<GameUser>>> Update([FromBody] GameUser user)
    {
        var result = await _gameUserRepository.UpdateAsync(user);
        var response = new Response<GameUser>{Data = result};
        return Ok(response);
    }
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _gameUserRepository.DeleteAsync(id);
        var response = new Response<bool>();
        return Ok(result);
    }
}