using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Service;

public interface ICartDetailService
{
    Task<List<CartDetail>> GetAllAsync(); 
    Task<CartDetail> GetByIdAsync(Guid id);
    Task<CartDetail> AddAsync(CartDetail cartDetail);
    Task<CartDetail> UpdateAsync(Guid id, CartDetail cartDetail);
    Task<bool> RemoveAsync(Guid id);
    
    //thêm 1 cuốn sách vào cart, kiểm tra xem sách đã tồn tại trong cart chưa
    //nếu đã tồn tại thì tăng số lượng sách lên 1
    Task AddBookToCart(SaveCartDetail cartDetail);
    
    //chỉnh sửa số lượng saách trong cart
    Task UpdateQuantity(SaveCartDetail cartDetail, int quantity);
    
    //xóa 1 sách khỏi cart
    Task RemoveBookFromCart(SaveCartDetail cartDetail);
    
    //xóa cart detail theo id cart
    Task RemoveCartDetailByCartId(Guid cartId);
    
}