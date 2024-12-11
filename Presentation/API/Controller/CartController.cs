using Application.DTO;
using Application.Interfaces.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    
    private readonly ICartService _cartService;
    
    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }
    
    //get all
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        
        var result = await _cartService.GetAllAsync();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _cartService.GetByIdAsync(id);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] SaveCart cart)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _cartService.AddAsync(cart);
        return Ok(result);
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] SaveCart cart)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _cartService.UpdateAsync(id, cart);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _cartService.RemoveAsync(id);
        return Ok(result);
    }
    
}