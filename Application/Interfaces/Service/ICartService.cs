using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces.Service;

public interface ICartService
{
    Task<List<Cart>> GetAllAsync();
    Task<CartResponse> GetByIdAsync(Guid id);
    Task<Cart> AddAsync(SaveCart cart);
    Task<Cart> UpdateAsync(Guid id, SaveCart cart);
    Task<bool> RemoveAsync(Guid id);
}