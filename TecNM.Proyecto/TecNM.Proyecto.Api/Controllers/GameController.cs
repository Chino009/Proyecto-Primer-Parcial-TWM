using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController: Controller
{
    private readonly IGameRepository _gameRepository;
    public GameController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<Game>>>> GetAll()
    {
        var game = await _gameRepository.GetAllAsync();
        var response = new Response<List<Game>>();
        response.Data = game;
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<Game>>> Post([FromBody] Game game)
    {
        game = await _gameRepository.SaveAsync(game);
        var response = new Response<Game>();
        response.Data = game;
        return Created($"/api/[controller]/{game.id}", response);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Game>>> GetById(int id)
    {
        var game = await _gameRepository.GetById(id);
        var response = new Response<Game>();
        response.Data = game;
        return Ok(response);
    }
    [HttpPut]
    public async Task<ActionResult<Response<Game>>> Update([FromBody] Game game)
    {
        var result = await _gameRepository.UpdateAsync(game);
        var response = new Response<Game>{Data = result};
        return Ok(response);
    }
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _gameRepository.DeleteAsync(id);
        var response = new Response<bool>();
        return Ok(result);
    }
}