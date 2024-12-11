using Domain.Entities;

namespace Application.Interfaces.Repository;

public interface ICartDetailRepository : IRepository<CartDetail>
{
    //thêm 1 cuốn sách vào cart, kiểm tra xem sách đã tồn tại trong cart chưa
    //nếu đã tồn tại thì tăng số lượng sách lên 1
    Task AddBookToCart(Guid cartId, Guid bookId);
    
    //chỉnh sửa số lượng saách trong cart
    Task UpdateQuantity(Guid cartId, Guid bookId, int quantity);
    
    //xóa 1 sách khỏi cart
    Task RemoveBookFromCart(Guid cartId, Guid bookId);
    
    //xóa cart detail theo id cart
    Task RemoveCartDetailByCartId(Guid cartId);
    
}