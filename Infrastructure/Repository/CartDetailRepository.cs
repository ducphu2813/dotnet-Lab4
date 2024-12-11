using Application.Interfaces.Repository;
using Domain.Entities;
using Domain.Exception;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CartDetailRepository : BaseRepository<CartDetail>, ICartDetailRepository
{
    public CartDetailRepository(DatabaseContext context) : base(context)
    {
    }
    
    //thêm 1 cuốn sách vào cart, kiểm tra xem sách đã tồn tại trong cart chưa
    //nếu đã tồn tại thì tăng số lượng sách lên 1
    public async Task AddBookToCart(Guid cartId, Guid bookId)
    {
        //kiểm tra xem book id có tồn tại ko
        var book = await _context.Books.FindAsync(bookId);
        
        if (book == null)
        {
            throw new NotFoundException("Book not found");
        }
        
        var cartDetail = await _context.CartDetails
            .FirstOrDefaultAsync(x => x.CartId == cartId && x.BookId == bookId);
        
        if (cartDetail == null)
        {
            cartDetail = new CartDetail
            {
                CartId = cartId,
                BookId = bookId,
                Quantity = 1,
                Price = await GetBookPriceAsync(bookId),
                Discount = 0,
                IsActive = true

            };
            await _context.CartDetails.AddAsync(cartDetail);
        }
        else
        {
            cartDetail.Quantity++;
            
            //tính lại price
            cartDetail.Price = await GetBookPriceAsync(bookId) * cartDetail.Quantity;
        }
        
    }
    
    private async Task<int> GetBookPriceAsync(Guid bookId)
    {
        var book = await _context.Books.FindAsync(bookId);
        return book?.Cost ?? 0;
    }

    
    //chỉnh sửa số lượng saách trong cart
    public async Task UpdateQuantity(Guid cartId, Guid bookId, int quantity)
    {
        
        //kiểm tra xem book id có tồn tại ko
        var book = await _context.Books.FindAsync(bookId);
        
        if (book == null)
        {
            throw new NotFoundException("Book not found");
        }
        
        var cartDetail = await _context.CartDetails
            .FirstOrDefaultAsync(x => x.CartId == cartId && x.BookId == bookId);
        
        if (cartDetail != null)
        {
            cartDetail.Quantity = quantity;
            
            //tính lại price
            cartDetail.Price = await GetBookPriceAsync(bookId) * cartDetail.Quantity;
        }
        
    }
    
    //xóa 1 sách khỏi cart
    public async Task RemoveBookFromCart(Guid cartId, Guid bookId)
    {
        
        var cartDetail = await _context.CartDetails
            .FirstOrDefaultAsync(x => x.CartId == cartId && x.BookId == bookId);
        
        if (cartDetail != null)
        {
            _context.CartDetails.Remove(cartDetail);
        }
        
    }
    
    //xóa cart detail theo id cart
    public async Task RemoveCartDetailByCartId(Guid cartId)
    {
        var cartDetails = await _context.CartDetails
            .Where(x => x.CartId == cartId)
            .ToListAsync();
        
        if (cartDetails.Count > 0)
        {
            _context.CartDetails.RemoveRange(cartDetails);
        }
        
    }
    
    //tìm cart detail theo 1 danh sách id book
    // public async Task<List<CartDetail>> GetByBookIdsAsync(List<Guid> bookIds)
    // {
    //     return await _context.CartDetails
    //         .Where(x => bookIds.Contains(x.BookId))
    //         .ToListAsync();
    // }
    
}