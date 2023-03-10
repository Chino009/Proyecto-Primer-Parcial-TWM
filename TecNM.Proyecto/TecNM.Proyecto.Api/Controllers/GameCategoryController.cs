using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Http;
namespace TecNM.Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameCategoryController: Controller
{
    private readonly IGameCategoryRepository _gameCategoryRepository;
    public GameCategoryController(IGameCategoryRepository gameCategoryRepository)
    {
        _gameCategoryRepository = gameCategoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<GameCategory>>>> GetAll()
    {
        var categories = await _gameCategoryRepository.GetAllAsync();
        var response = new Response<List<GameCategory>>();
        response.Data = categories;
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<GameCategory>>> Post([FromBody] GameCategory category)
    {
        category = await _gameCategoryRepository.SaveAsync(category);
        var response = new Response<GameCategory>();
        response.Data = category;
        return Created($"/api/[controller]/{category.id}", response);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<GameCategory>>> GetById(int id)
    {
        var category = await _gameCategoryRepository.GetById(id);
        var response = new Response<GameCategory>();
        response.Data = category;
        return Ok(response);
    }
    [HttpPut]
    public async Task<ActionResult<Response<GameCategory>>> Update([FromBody] GameCategory category)
    {
        var result = await _gameCategoryRepository.UpdateAsync(category);
        var response = new Response<GameCategory>{Data = result};
        return Ok(response);
    }
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _gameCategoryRepository.DeleteAsync(id);
        var response = new Response<bool>();
        return Ok(result);
    }
}