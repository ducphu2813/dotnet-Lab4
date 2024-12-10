using Domain.Entities;

namespace Application.Interfaces.Service;

public interface ICartDetailService
{
    Task<List<CartDetail>> GetAllAsync(); 
    Task<CartDetail> GetByIdAsync(Guid id);
    Task<CartDetail> AddAsync(CartDetail cartDetail);
    Task<CartDetail> UpdateAsync(Guid id, CartDetail cartDetail);
    Task<bool> RemoveAsync(Guid id);
}