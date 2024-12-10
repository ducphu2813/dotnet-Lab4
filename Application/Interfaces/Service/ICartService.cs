using Domain.Entities;

namespace Application.Interfaces.Service;

public interface ICartService
{
    Task<List<Cart>> GetAllAsync();
    Task<Cart> GetByIdAsync(Guid id);
    Task<Cart> AddAsync(Cart cart);
    Task<Cart> UpdateAsync(Guid id, Cart cart);
    Task<bool> RemoveAsync(Guid id);
}