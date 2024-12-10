using Application.DTO;
using Application.Interfaces.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    
    protected readonly IGenreService _genreService;
    
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }
    
    //get all
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        
        var result = await _genreService.GetAllAsync();
        return Ok(result);
    }
    
    //get by id
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _genreService.GetByIdAsync(id);
        return Ok(result);
    }
    
    //thêm
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddGenre genre)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _genreService.AddAsync(genre);
        return Ok(result);
    }
    
    //update
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] Genre genre)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _genreService.UpdateAsync(id, genre);
        return Ok(result);
    }
    
    //del
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> RemoveAsync(Guid id)
    {
        var result = await _genreService.RemoveAsync(id);
        return Ok(result);
    }
    
}