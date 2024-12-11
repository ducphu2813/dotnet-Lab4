using Application.DTO;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class CartDetailController : ControllerBase
{
    private readonly ICartDetailService _cartDetailService;
    
    public CartDetailController(ICartDetailService cartDetailService)
    {
        _cartDetailService = cartDetailService;
    }
    
    //thêm sách vào cart
    [HttpPost]
    [Route("add-book-to-cart")]
    public async Task<IActionResult> AddBookToCart([FromBody] SaveCartDetail cartDetail)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _cartDetailService.AddBookToCart(cartDetail);
        return Ok();
    }
    
    //chỉnh sửa số lượng sách trong cart
    [HttpPut]
    [Route("update-quantity/{quantity}")]
    public async Task<IActionResult> UpdateQuantity([FromBody] SaveCartDetail cartDetail, int quantity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _cartDetailService.UpdateQuantity(cartDetail, quantity);
        return Ok();
    }
    
    //xóa sách khỏi cart
    [HttpPost]
    [Route("remove-book-from-cart")]
    public async Task<IActionResult> RemoveBookFromCart([FromBody] SaveCartDetail cartDetail)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _cartDetailService.RemoveBookFromCart(cartDetail);
        return Ok();
    }
    
    //xóa cart detail theo id cart
    [HttpDelete]
    [Route("remove-cart-detail-by-cart-id/{cartId}")]
    public async Task<IActionResult> RemoveCartDetailByCartId(Guid cartId)
    {
        await _cartDetailService.RemoveCartDetailByCartId(cartId);
        return Ok();
    }
}