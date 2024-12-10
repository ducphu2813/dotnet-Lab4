using Application.Interfaces.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    protected readonly IBookService _bookService;
    
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    //lấy ra tất cả sách
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        
        var result = await _bookService.GetAllAsync();
        return Ok(result);
    }
    
    //lấy ra sách theo id
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _bookService.GetByIdAsync(id);
        return Ok(result);
    }
    
    //thêm sách
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] Book book)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _bookService.AddAsync(book);
        return Ok(result);
    }
    
    //update sách
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] Book book)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var result = await _bookService.UpdateAsync(id, book);
        return Ok(result);
    }
    
    //xóa sách
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> RemoveAsync(Guid id)
    {
        var result = await _bookService.RemoveAsync(id);
        return Ok(result);
    }
    
}